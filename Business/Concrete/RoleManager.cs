using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.Identity;
using Entities.Dtos.RoleDto;

namespace Business.Concrete;

public class RoleManager : IRoleService
{
    private readonly IRoleDal _roleDal;

    public RoleManager(IRoleDal roleDal)
    {
        _roleDal = roleDal;
    }

    public void CreateRole(RoleDto roleForInsertion)
    {
        throw new NotImplementedException();
    }

    public void UpdateRole(RoleDto roleForUpdate)
    {
        throw new NotImplementedException();
    }

    public void DeleteRole(Role role)
    {
        throw new NotImplementedException();
    }

    public List<Role> FindAllWithAsNoTracking(bool trackChanges)
    {
        return _roleDal.FindAllWithAsNoTracking(trackChanges).ToList();
    }
}