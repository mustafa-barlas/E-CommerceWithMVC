using Business.Abstract;
using Entities.Dtos.UserDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
{
    private readonly IUserService _userService;


    public UserForRegisterValidator(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));

        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name can not be empty.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name can not be empty.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email can not be empty.")
            .EmailAddress().WithMessage("Please enter a valid email address.")
            .Must(BeUniqueEmail).WithMessage("Email already has been taken");



        RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.");
        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords do not match.")
            .NotEmpty().WithMessage("Confirm password can not be empty.");
    }

    private bool BeUniqueEmail(string email)
    {


        if (_userService == null)
        {
            return false;
        }

        var users = _userService.GetUsers().ToList();
        var isUnique = !users.Any(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        return isUnique;

    }
}