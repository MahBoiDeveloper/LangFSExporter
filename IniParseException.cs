using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LangFSExporter
{
    class IniParseException : Exception
    {
        public IniParseException(string message) : base(message)
        {
        }
    }
}
