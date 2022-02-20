using System;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests
{
    class TestOutputLogger : ILogger
    {
        private readonly ITestOutputHelper testOutput;

        public TestOutputLogger(ITestOutputHelper testOutput)
        {
            this.testOutput = testOutput;
        }

        public void LogError(string message) => testOutput.WriteLine($"[Error] {message}");

        public void LogException(Exception exception) => testOutput.WriteLine(exception.ToString());

        public void LogInformation(string message) => testOutput.WriteLine(message);

        public void LogWarning(string message) => testOutput.WriteLine($"[Warning] {message}");
    }
}
