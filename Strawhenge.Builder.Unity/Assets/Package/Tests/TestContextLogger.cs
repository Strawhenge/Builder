using NUnit.Framework;
using Strawhenge.Common.Logging;
using System;

namespace Strawhenge.Builder.Unity.Tests
{
    public class TestContextLogger : ILogger
    {
        public void LogInformation(string message)
        {
            TestContext.WriteLine($"[Information] {message}");
        }

        public void LogWarning(string message)
        {
            TestContext.WriteLine($"[Warning] {message}");
        }

        public void LogError(string message)
        {
            TestContext.WriteLine($"[Error] {message}");
        }

        public void LogException(Exception exception)
        {
            TestContext.WriteLine(exception.ToString());
        }
    }
}