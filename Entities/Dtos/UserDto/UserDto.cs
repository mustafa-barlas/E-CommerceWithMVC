using Core.Entities;
using Entities.Concrete.Identity;

namespace Entities.Dtos.UserDto;

public record UserDto : IDto
{


    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? FullName => $"{FirstName} {LastName}";

    public string Password { get; set; }

    public string Email { get; set; }

    public bool IsActive { get; set; } = true;

    public int? RoleId { get; set; }

    public virtual Role Role { get; set; }

    

    public UserDto(string firstName,string lastName, string password, string email, bool isActive, int roleId, int userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        IsActive = isActive;
        RoleId = roleId;
        UserId = userId;

        Role = new Role();
    }

    public UserDto()
    {
        Role = new Role();
    }
    
}