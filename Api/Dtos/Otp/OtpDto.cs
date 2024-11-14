namespace Api.Dtos.Otp;

public record class OtpDto(int id, int Code, string Creator, int OrganizationId, Boolean IsUsed, DateTime CreatedAt);
