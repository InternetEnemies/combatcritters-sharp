namespace CombatCrittersSharp.rest.payloads;

/// <summary>
/// payload for login requests
/// </summary>
/// <param name="username"></param>
/// <param name="password"></param>
public record LoginPayload(string username, string password);