using FluentValidation;

public class LoginAnagraficaViewModelValidator : AbstractValidator<LoginAnagraficaViewModel>
{
    public LoginAnagraficaViewModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("L'email è obbligatoria.")
            .EmailAddress().WithMessage("L'email deve essere valida e confermata.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("La password è obbligatoria.")
            .MinimumLength(6).WithMessage("La password deve contenere almeno 6 caratteri.");
    }
}
