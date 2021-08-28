using System;

namespace LangFSExporter
{
    [Flags]
    public enum BooleanStringStyle
    {
        TRUEFALSE = 0,
        YESNO = 1,
        TRUEFALSE_LOWERCASE = 2,
        YESNO_LOWERCASE = 3,
        ONEZERO = 4
    }
}
