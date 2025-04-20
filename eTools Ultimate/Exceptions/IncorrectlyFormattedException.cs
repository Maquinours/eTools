using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Exceptions
{
    public class IncorrectlyFormattedFileException : Exception
    {
        public IncorrectlyFormattedFileException(string filePath)
            :
            base(string.Format(Resources.ExceptionMessages.IncorrectlyFormattedFile, filePath))
        { }
    }
}
