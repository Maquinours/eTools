using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Exceptions
{
    public class SoundConfigNotFoundException : Exception
    {
        public SoundConfigNotFoundException(int id)
            :
            base(string.Format(Resources.ExceptionMessages.SoundConfigNotFound, id))
        { }
    }
}
