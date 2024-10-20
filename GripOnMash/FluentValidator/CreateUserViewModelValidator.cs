namespace GripOnMash.FluentValidator
{
    public class CreateUserViewModelValidator : AbstractValidator<CreateUserViewModel>
    {
        public CreateUserViewModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Il Nome Utente è obbligatorio.")
                .Matches(@"^\S*$").WithMessage("Il nome utente non può contenere spazi.")
                .MaximumLength(50).WithMessage("Il Nome Utente non può superare i 50 caratteri.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("L'Email è obbligatoria.")
                .EmailAddress().WithMessage("Inserisci un indirizzo email valido.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\d{10}$").When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage("Il Numero di Telefono deve contenere esattamente 10 cifre.");
        }
    }
}
