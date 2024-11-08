namespace CombatCrittersSharp.exception;

/// <summary>
/// provide exception for authentication errors
/// </summary>
/// <param name="message"></param>
/// <param name="inner"></param>
public class AuthException(string message, Exception? innerException = null) : CombatCrittersException(message, "Authorization error: " + message, innerException)
{
}