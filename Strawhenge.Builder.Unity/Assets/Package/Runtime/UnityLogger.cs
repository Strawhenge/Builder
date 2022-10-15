using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class UnityLogger : ILogger
    {
        readonly GameObject _context;

        public UnityLogger(GameObject context)
        {
            _context = context;
        }

        public void LogError(string message) => Debug.LogError(message, _context);

        public void LogException(Exception exception) => Debug.LogException(exception, _context);

        public void LogInformation(string message) => Debug.Log(message, _context);

        public void LogWarning(string message) => Debug.LogWarning(message, _context);
    }
}