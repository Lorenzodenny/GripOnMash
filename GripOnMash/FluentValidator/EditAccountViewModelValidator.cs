namespace GripOnMash.FluentValidator
{
    public class EditAccountViewModelValidator : AbstractValidator<EditAccountViewModel>
    {
        public EditAccountViewModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Il nome utente è obbligatorio.")
                .Matches(@"^\S*$").WithMessage("Il nome utente non può contenere spazi.")
                .MaximumLength(50).WithMessage("Il Nome Utente non può superare i 50 caratteri.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("L'email è obbligatoria.")
                .EmailAddress().WithMessage("Inserisci un indirizzo email valido.");

            // Validazione condizionale per le password
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().When(x => !string.IsNullOrWhiteSpace(x.NewPassword))
                .WithMessage("La password attuale è obbligatoria se vuoi cambiare la password.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().When(x => !string.IsNullOrWhiteSpace(x.CurrentPassword))
                .WithMessage("La nuova password è obbligatoria.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword).When(x => !string.IsNullOrWhiteSpace(x.NewPassword))
                .WithMessage("Le password non coincidono.");
        }
    }

}
