#if __MOVERS || __ITEMS
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
#elif __ITEMS
            base(string.Format(ItemsEditor.Resources.ExceptionMessages.IncorrectlyFormattedFile, filePath))
#endif
        { }
    }

    public class MissingDefineException : Exception
    {
        public MissingDefineException(string defineIdentifier)
            :
#if __MOVERS
            base(string.Format(MoversEditor.Resources.ExceptionMessages.MissingDefine, defineIdentifier))
#elif __ITEMS
            base(string.Format(ItemsEditor.Resources.ExceptionMessages.MissingDefine, defineIdentifier))
#endif
        { }
    }
}
#endif