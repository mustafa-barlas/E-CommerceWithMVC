using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, AlalimContext>, IUserDal
{
    //public List<OperationClaim> GetClaims(User user)
    //{
    //    using (var _context = new AlalimContext())
    //    {
    //        var result = from operationClaim in _context.OperationClaims
    //                     join userOperationClaim in _context.UserOperationClaims on operationClaim.Id equals userOperationClaim
    //                         .OperationClaimId
    //                     where userOperationClaim.UserId == user.Id
    //                     select new OperationClaim
    //                     {
    //                         Id = operationClaim.Id,
    //                         Name = operationClaim.Name,
    //                     };

    //        return result.ToList();
    //    }
    //}
}