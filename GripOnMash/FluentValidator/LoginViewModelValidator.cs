namespace GripOnMash.FluentValidator
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Input)
                .NotEmpty().WithMessage("Email o Matricola è obbligatoria.")
                .MaximumLength(100).WithMessage("Email o Matricola non può superare 100 caratteri.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La Password è obbligatoria.");
        }
    }
}
