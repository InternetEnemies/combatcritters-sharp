namespace CombatCrittersSharp.exception
{
    public class CombatCrittersException : Exception
    {
        public CombatCrittersException(string message) : base(message) { }

        public CombatCrittersException(string message, Exception innerException) : base(message, innerException) { }
    }
}
