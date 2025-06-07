using Application_Layer.Commands.UserCommands.CreateAUser;
using FluentValidation;

public class CreateAUserCommandValidator : AbstractValidator<CreateAUserCommand>
{
    public CreateAUserCommandValidator()
    {
        RuleFor(cmd => cmd.UserDto).SetValidator(new UserDtoValidator());
    }
}
