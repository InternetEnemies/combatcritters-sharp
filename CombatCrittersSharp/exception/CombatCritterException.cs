namespace CombatCrittersSharp.exception
{
    public class CombatCrittersException(string message, string? detailedMessage = null, Exception? innerException = null) : Exception(message, innerException)
    {
        public string? DetailedMessage { get; } = detailedMessage;

        public override string ToString()
        {
            return $"{base.ToString()}\nDetailed Info: {DetailedMessage ?? "No additional details provided."}";
        }
    }
}
