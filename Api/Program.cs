
using System.Text;
using Api.Data;
using Api.Interfaces;
using Api.Models;
using Api.Repos;
using Api.Services;
using Api.Services.Authorization;
using Api.Services.Authorization.Handler;
using Api.Services.Authorization.Requirement;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter ' your token in the text input below. Example: \" {your_token}\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders()
    .AddApiEndpoints();

builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("SpecialAdmin", policy =>
            {
                policy.Requirements.Add(new SpecialAdminRequirement());
            }
            
        );
        options.AddPolicy("GlobalAdmin", policy =>
            {
                policy.RequireClaim("OrganisationId", "1");
                policy.RequireRole("Admin");
            }
            
        );
          options.AddPolicy("GroupAdmin", policy =>
            {
                policy.Requirements.Add(new GroupAdminRequirement());
            }
            
        );
        options.AddPolicy("OtpAccess", policy =>
            {
                policy.Requirements.Add(new OtpAccessRequirement());
            }
            
        );
    }
    );

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
           options.TokenValidationParameters = new TokenValidationParameters
    {
        // Maps "given_name" from the token to User.Identity.Name
        //NameClaimType = "given_name",
        
        // Validates that the token issuer matches the expected issuer
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],

        // Validates that the token audience matches the expected audience
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],

        // Ensures the token is not expired
        ValidateLifetime = true,

        // Ensures the token is signed with the expected key
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
        options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine("Token invalid: " + context.Exception.Message);
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            Console.WriteLine("Token valid");
            return Task.CompletedTask;
        }
    };
        
    });


builder.Services.AddScoped<IOtpRepo, OtpRepo>();
builder.Services.AddScoped<IOrgRepo, OrgRepo>();
builder.Services.AddScoped<IDoorRepo, DoorRepo>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IAuthorizationHandler, SpecialAdminHandler>();
builder.Services.AddScoped<IAuthorizationHandler, GroupAdminHandler>();
builder.Services.AddScoped<IAuthorizationHandler, OtpAccessHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();


app.UseHttpsRedirection();
app.MapControllers();



app.Run();


