using Core.Entities;

namespace Entities.Dtos.UserDto;

public record UserForLoginDto : IDto
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string? ReturnUrl { get; set; }

}