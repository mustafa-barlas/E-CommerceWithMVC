using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Identity;
using Entities.Dtos.UserDto;

namespace Business.Concrete;

public class AccountManager : IAccountService
{
    private readonly IUserDal _userDal;
    private readonly IMapper _mapper;

    public AccountManager(IMapper mapper, IUserDal userDal)
    {
        _mapper = mapper;
        _userDal = userDal;
    }

    public Result Login(UserForLoginDto userForLoginDto, UserDto userDto)
    {

        var result = _userDal.GetUsers().SingleOrDefault(x => x.Email.Equals(userForLoginDto.Email) && x.Password.Equals(userForLoginDto.Password));


        if (result is null)
        {

            return new ErrorResult(Messages.UserNotFound);
        }


        var map = _mapper.Map<UserDto>(result);
        userDto.Email = map.Email;
        userDto.Role.Name = map.Role.Name;
        userDto.UserId = result.Id;
        userDto.FirstName = map.FirstName;
        userDto.LastName = map.LastName;

        return new SuccessResult();

    }

    public Result Register(UserForRegisterDto userForRegisterDto)
    {

        var user = _mapper.Map<User>(userForRegisterDto);
        user.IsActive = true;
        user.RoleId = 2;
        _userDal.Add(user);
        return new SuccessResult();
    }
}