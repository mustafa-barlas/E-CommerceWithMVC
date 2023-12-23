using Entities.Concrete.Identity;
using Entities.Dtos.RoleDto;

namespace Business.Abstract;

public interface IRoleService
{

    void CreateRole(RoleDto roleForInsertion);

    void UpdateRole(RoleDto roleForUpdate);

    void DeleteRole(Role role);

    List<Role> FindAllWithAsNoTracking(bool trackChanges);
}