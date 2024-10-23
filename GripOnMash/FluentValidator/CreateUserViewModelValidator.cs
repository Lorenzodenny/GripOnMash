namespace GripOnMash.FluentValidator
{
    public class CreateUserViewModelValidator : AbstractValidator<CreateUserViewModel>
    {
        public CreateUserViewModelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Il Nome è obbligatorio.")
                .Matches(@"^\S*$").WithMessage("Il nome non può contenere spazi.")
                .MaximumLength(50).WithMessage("Il Nome non può superare i 50 caratteri.");

            RuleFor(x => x.Cognome)
              .NotEmpty().WithMessage("Il Cognome è obbligatorio.")
              .Matches(@"^\S*$").WithMessage("Il Cognome non può contenere spazi.")
              .MaximumLength(50).WithMessage("Il Cognome non può superare i 50 caratteri.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("L'Email è obbligatoria.")
                .EmailAddress().WithMessage("Inserisci un indirizzo email valido.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\d{10}$").When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage("Il Numero di Telefono deve contenere esattamente 10 cifre.");
        }
    }
}
