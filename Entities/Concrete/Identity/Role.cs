using Core.Entities;
namespace Entities.Concrete.Identity;

public class Role :  IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();

   
}