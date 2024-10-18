
namespace DashboardCCA.Api.Features.Authentication;

public static class AuthenticationError
{
    public static Error UserNotEnable =>
        Error.Conflict(code: "InternalUser.UserNotEnable", description: "Utente non abilitato");

    public static Error ValidateError(string e) =>
        Error.Validation(code: "InternalUser.ValidateError", description: e);
    public static Error UserNotFound =>
        Error.NotFound(code: "InternalUser.UserNotFound", description: "Utente non trovato");
    public static Error MatricolaNotFound =>
        Error.NotFound(code: "InternalUser.MatricolaNotFound", description: "Matricola non trovata");

    public static Error InvalidCredential =>
        Error.Validation(code: "InternalUser.InvalidCredential", description: "La combinazione matricola e password non sono validi");

    public static Error LogoutSessionNotFound =>
        Error.Validation(code: "InternalUser.LogoutSessionNotFound", description: "Sessione utente non trovata");

    public static Error RefreshTokenNotValid =>
        Error.Validation(code: "InternalUser.RefreshTokenNotValid", description: "Il token richiesto non è idoneo all' aggiornamento");

    public static Error Failure(
        string e,
        string? exMessage = null,
        string? exStackTrace = null,
        Dictionary<string, string>? customValues = null
    ) => Error.Failure(code: "InternalUser.GenericError", description: e, exMessage, exStackTrace, customValues);
}
