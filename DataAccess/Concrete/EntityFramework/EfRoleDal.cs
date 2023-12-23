using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Identity;

namespace DataAccess.Concrete.EntityFramework;
 
public class EfRoleDal : EfEntityRepositoryBase<Role, AlalimContext> , IRoleDal
{
    
}