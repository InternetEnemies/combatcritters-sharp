using System.Text;

namespace CombatCrittersSharp.exception
{
    public static class GeneralExceptionHandler
    {
        public static void HandleException(Exception ex, string? customMessage = null)
        {
            string detailedMessage = GenerateDetailedMessage(ex);

            // Log the exception with details
            LogException(ex, customMessage);

            // Re-throw a new CombatCrittersException with detailed information
            throw new CombatCrittersException(
                customMessage ?? "An error occurred in CombatCrittersSharp wrapper.",
                detailedMessage,
                ex
            );
        }

        private static string GenerateDetailedMessage(Exception ex)
        {
            StringBuilder details = new StringBuilder();
            details.AppendLine("Exception Details:");

            switch (ex)
            {
                case AuthException authEx:
                    details.AppendLine("Authorization error.");
                    break;
                case RestException restEx:
                    details.AppendLine($"REST error - Status Code: {restEx.StatusCode}");
                    details.AppendLine($"Response Content: {restEx.ResponseContent ?? "No response content"}");
                    break;
                case TimeoutException:
                    details.AppendLine("Operation timed out.");
                    break;
                case ArgumentException argEx:
                    details.AppendLine($"Invalid argument: {argEx.Message}");
                    break;
                default:
                    details.AppendLine("Unexpected error.");
                    break;
            }

            details.AppendLine($"Message: {ex.Message}");
            if (ex.InnerException != null)
            {
                details.AppendLine($"Inner Exception: {ex.InnerException.Message}");
                details.AppendLine($"Inner Stack Trace: {ex.InnerException.StackTrace}");
            }

            details.AppendLine($"Stack Trace: {ex.StackTrace}");
            return details.ToString();
        }

        private static void LogException(Exception ex, string? message)
        {
            Console.WriteLine($"{message ?? "Error"} - {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");

            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                Console.WriteLine($"Inner Stack Trace: {ex.InnerException.StackTrace}");
            }

            // Log additional details for RestException
            if (ex is RestException restEx)
            {
                Console.WriteLine($"HTTP Status Code: {restEx.StatusCode}");
                Console.WriteLine($"Response Content: {restEx.ResponseContent ?? "No response content"}");
            }
        }
    }
}
