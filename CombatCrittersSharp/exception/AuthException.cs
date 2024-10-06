namespace CombatCrittersSharp.exception;

public class AuthException(string message, Exception inner) : Exception(message, inner);