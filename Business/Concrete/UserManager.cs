using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.Identity;
using Entities.Dtos.ProductDto;
using Entities.Dtos.UserDto;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly IMapper _mapper;

    public UserManager(IUserDal userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }

   
    public List<User> GetAll()
    {
        return _userDal.FindAllWithAsNoTracking(true).ToList();
    }

    public User? FindByConditionWithAsNoTracking(int userId, bool trackChanges)
    {
       return _userDal.FindByConditionAndAsNoTracking(x => x.Id.Equals(userId), trackChanges);
    }

    public List<User> GetByRoleId(int? roleId = null)
    {
        if (roleId != null)
        {
            return _userDal.GetUsers().Where(x => x.RoleId.Equals(roleId)).ToList();
        }

        return _userDal.GetUsers().ToList();
    }


    public ProductDtoForUpdate GetOneUserForUpdate(int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void CreateUser(UserForRegisterDto userForRegisterDto)
    {
        var user = _mapper.Map<User>(userForRegisterDto);
        _userDal.Add(user);
    }

    public void UpdateUser(UserForRegisterDto userForUpdateDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(User user)
    {
        //var entity = _userDal.FindByConditionAndAsNoTracking(x => x.Id.Equals(user.Id),true);
        //entity.IsActive = false;
    }

    public IQueryable<User> GetUsers()
    {
        return _userDal.GetUsers(); 
    }
}