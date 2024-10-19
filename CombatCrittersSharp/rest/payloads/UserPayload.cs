namespace CombatCrittersSharp.rest.payloads;

/// <summary>
/// user api payload
/// </summary>
/// <param name="id"></param>
/// <param name="username"></param>
public record UserPayload(int id, string username);