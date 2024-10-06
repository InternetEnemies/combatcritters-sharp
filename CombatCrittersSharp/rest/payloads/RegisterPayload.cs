namespace CombatCrittersSharp.rest.payloads;

/// <summary>
/// payload for register requests
/// </summary>
/// <param name="username"></param>
/// <param name="password"></param>
public record RegisterPayload(string username, string password);