using Entities.Concrete.Identity;
using Entities.Dtos.ProductDto;
using Entities.Dtos.UserDto;

namespace Business.Abstract;

public interface IUserService
{

    List<User> GetAll();

    IQueryable<User> GetUsers();

    User? FindByConditionWithAsNoTracking(int userId, bool trackChanges);

    List<User> GetByRoleId(int? roleId = null);

    ProductDtoForUpdate GetOneUserForUpdate(int id, bool trackChanges);

    void CreateUser(UserForRegisterDto userForRegisterDto);

    void UpdateUser(UserForRegisterDto userForUpdateDto);

    void DeleteUser(User user);
}