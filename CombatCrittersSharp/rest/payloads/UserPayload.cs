namespace CombatCrittersSharp.rest.payloads;

/// <summary>
/// user api payload
/// </summary>
/// <param name="userid"></param>
/// <param name="username"></param>
public record UserPayload(int userid, string username);