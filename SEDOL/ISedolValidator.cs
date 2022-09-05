using System;
using System.Collections.Generic;
using System.Text;

namespace SEDOL
{
    public interface ISedolValidator
    {
        ISedolValidationResult ValidateSedol(string input);
    }
}
