using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Exceptions
{
    public class IncorrectlyFormattedFileException(string filePath) : Exception(string.Format(Resources.ExceptionMessages.IncorrectlyFormattedFile, filePath))
    {
        public string FilePath { get; } = filePath;
    }
}
