using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class UnityLogger : ILogger
    {
        readonly GameObject context;

        public UnityLogger(GameObject context)
        {
            this.context = context;
        }

        public void LogError(string message) => Debug.LogError(message, context);

        public void LogException(Exception exception) => Debug.LogException(exception, context);

        public void LogInformation(string message) => Debug.Log(message, context);

        public void LogWarning(string message) => Debug.LogWarning(message, context);
    }
}
