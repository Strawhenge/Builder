using System;
using Xunit.Abstractions;

namespace Strawhenge.Builder.Tests
{
    class TestOutputLogger : ILogger
    {
        private readonly ITestOutputHelper _testOutput;

        public TestOutputLogger(ITestOutputHelper testOutput)
        {
            this._testOutput = testOutput;
        }

        public void LogError(string message) => _testOutput.WriteLine($"[Error] {message}");

        public void LogException(Exception exception) => _testOutput.WriteLine(exception.ToString());

        public void LogInformation(string message) => _testOutput.WriteLine(message);

        public void LogWarning(string message) => _testOutput.WriteLine($"[Warning] {message}");
    }
}
