using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Common
{
    public static class ErrorMessages
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager($"{typeof(ErrorMessages).Assembly.GetName().Name}.Resources.ExceptionMessages", typeof(ErrorMessages).Assembly);

        public static string GetMessage(string key, params object[] args)
        {
            string message = ResourceManager.GetString(key) ?? key;
            return string.Format(message, args);
        }
    }

    public class IncorrectlyFormattedFileException : Exception
    {
        public IncorrectlyFormattedFileException(string filePath)
            : base(ErrorMessages.GetMessage("IncorrectlyFormattedFile", filePath)) { }
    }

    public class MissingDefineException : Exception
    {
        public MissingDefineException(string defineIdentifier)
            : base(ErrorMessages.GetMessage("MissingDefine", defineIdentifier)) { }
    }
}