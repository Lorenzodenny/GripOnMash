namespace GripOnMash.FluentValidator
{
    public class ForgottenPasswordViewModelValidator : AbstractValidator<ForgottenPasswordViewModel>
    {
        public ForgottenPasswordViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("L'email è obbligatoria.")
                .EmailAddress().WithMessage("Inserisci un'email valida.");
        }
    }
}
