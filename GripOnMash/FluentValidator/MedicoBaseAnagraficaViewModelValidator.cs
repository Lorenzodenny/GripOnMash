namespace GripOnMash.FluentValidator
{
    public class MedicoBaseAnagraficaViewModelValidator : AbstractValidator<MedicoBaseAnagraficaViewModel>
    {
        public MedicoBaseAnagraficaViewModelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Il nome è obbligatorio.")
                .MaximumLength(50).WithMessage("Il nome non può superare i 50 caratteri.");

            RuleFor(x => x.Cognome)
                .NotEmpty().WithMessage("Il cognome è obbligatorio.")
                .MaximumLength(50).WithMessage("Il cognome non può superare i 50 caratteri.");

            RuleFor(x => x.Eta)
                .GreaterThan(0).WithMessage("L'età deve essere maggiore o uguale a 0.");

            RuleFor(x => x.CodiceFiscale)
                .NotEmpty().WithMessage("Il codice fiscale è obbligatorio.")
                .Length(16).WithMessage("Il codice fiscale deve essere di 16 caratteri.");

            RuleFor(x => x.Indirizzo)
                .NotEmpty().WithMessage("L'indirizzo è obbligatorio.");

            RuleFor(x => x.Specializzazione)
                .NotEmpty().WithMessage("La specializzazione è obbligatoria.");

            RuleFor(x => x.NumeroAlbo)
                .NotEmpty().WithMessage("Il numero di albo è obbligatorio.");

            RuleFor(x => x.EmailPersonale)
                .NotEmpty().WithMessage("L'email personale è obbligatoria.")
                .EmailAddress().WithMessage("Inserisci un indirizzo email valido.");

            RuleFor(x => x.PartitaIVA)
                .NotEmpty().WithMessage("La partita IVA è obbligatoria.")
                .Length(11).WithMessage("La partita IVA deve essere di 11 cifre.");
        }
    }
}
