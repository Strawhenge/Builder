using System;

namespace Strawhenge.Builder
{
    public interface ILogger
    {
        void LogInformation(string message);

        void LogWarning(string message);

        void LogError(string message);

        void LogException(Exception exception);
    }
}
