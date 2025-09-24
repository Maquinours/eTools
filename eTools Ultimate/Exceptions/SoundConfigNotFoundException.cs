using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Exceptions
{
    public class SoundConfigNotFoundException(int id) : Exception
    {
        public int Id { get; } = id;
    }
}
