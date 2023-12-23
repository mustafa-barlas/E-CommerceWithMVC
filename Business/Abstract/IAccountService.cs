using Core.Utilities.Results;
using Entities.Dtos.UserDto;

namespace Business.Abstract;

public interface IAccountService
{
    Result Login(UserForLoginDto userForLoginDto, UserDto userDto);

    Result Register(UserForRegisterDto userForRegisterDto);


}