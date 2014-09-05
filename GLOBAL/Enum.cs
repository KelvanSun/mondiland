using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Global
{
    public enum CodeType
    {
        Ok,
        Error,
    }

    public class SaveResult
    {
        public CodeType Code;
        public string Message = string.Empty;
    }
}
