namespace Api.Dtos.Otp;

public record class CreateOtpDto(int Code,string Creator, int OrganizationId);

