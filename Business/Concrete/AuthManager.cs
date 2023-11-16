using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos.UserDto;
using User = Core.Entities.Concrete.User;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;

    public AuthManager(ITokenHelper tokenHelper, IUserService userService)
    {
        _tokenHelper = tokenHelper;
        _userService = userService;
    }

    public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

        var user = new User
        {
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };

        _userService.Add(user);
        return new SuccessDataResult<User>(user, Messages.UserRegistered);
    }

    public IDataResult<User> Login(UserForLoginDto userForLoginDto)
    {
        var userToCheck = _userService.GetByMail(userForLoginDto.Email);

        if (userToCheck is null)
        {
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }

        if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
            return new ErrorDataResult<User>(Messages.PasswordError);
        }

        return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
    }

    public IResult UserExists(string email)
    {
        if (_userService.GetByMail(email) is null)
        {
            return new ErrorResult(Messages.UserAlreadyExists);
        }

        return new SuccessResult();
    }

    public IDataResult<AccessToken> CreateAccessToken(User user)
    {
        var claims = _userService.GetClaims(user);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
    }
}