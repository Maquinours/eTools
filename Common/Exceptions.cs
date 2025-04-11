#if __MOVERS
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Common
{
    public class IncorrectlyFormattedFileException : Exception
    {
        public IncorrectlyFormattedFileException(string filePath)
            :
#if __MOVERS
            base(string.Format(MoversEditor.Resources.ExceptionMessages.IncorrectlyFormattedFile, filePath)) 
#endif
        { }
    }

    public class MissingDefineException : Exception
    {
        public MissingDefineException(string defineIdentifier)
            :
#if __MOVERS
            base(string.Format(MoversEditor.Resources.ExceptionMessages.MissingDefine, defineIdentifier))
#endif
            { }
    }
}
#endif