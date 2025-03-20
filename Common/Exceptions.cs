using System;

namespace Common
{
    public class IncorrectlyFormattedFileException : Exception
    {
        public IncorrectlyFormattedFileException(string filePath)
            : base($"The file \"{filePath}\" is incorrectly formatted") { }
    }

    public class MissingDefineException : Exception
    {
        public MissingDefineException(string defineIdentifier)
            : base($"\"{defineIdentifier}\" is missing.") { }
    }
}