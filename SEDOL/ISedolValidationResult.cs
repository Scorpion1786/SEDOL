using System;
using System.Collections.Generic;
using System.Text;

namespace SEDOL
{
    public interface ISedolValidationResult
    {
        string InputString { get; }
        bool IsValidSedol { get; }
        bool IsUserDefined { get; }
        string ValidationDetails { get; }
    }
}
