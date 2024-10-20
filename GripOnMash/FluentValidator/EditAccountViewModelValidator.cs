namespace GripOnMash.FluentValidator
{
    public class EditAccountViewModelValidator : AbstractValidator<EditAccountViewModel>
    {
        public EditAccountViewModelValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Inserisci un indirizzo email valido.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email)); 

            RuleFor(x => x.UserName)
                .Matches(@"^\S*$").WithMessage("Il nome utente non può contenere spazi.")
                .When(x => !string.IsNullOrWhiteSpace(x.UserName));

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("La password attuale è obbligatoria.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("La nuova password è obbligatoria.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword).WithMessage("Le password non coincidono.");
        }
    }
}
