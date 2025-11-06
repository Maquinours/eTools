using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public static class Constants
    {
        private static string[] _modelFilenameRoot = [
            "obj",
            "ani",
            "ctrl",
            "sfx",
            "item",
            "mvr",
            "region",
            "obj",		// ship
            "path"
            ];

        public static string[] ModelFilenameRoot => _modelFilenameRoot;

        public const uint NullId = 0xffffffff;
    }
}
