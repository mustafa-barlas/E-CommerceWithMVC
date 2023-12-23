using Core.Entities;

namespace Entities.Concrete.Identity;

public class User : IEntity 
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? FullName => $"{FirstName} {LastName}";

    public string Password { get; set; }

    public string Email { get; set; }

    public bool IsActive { get; set; } = true;

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();


}