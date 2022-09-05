using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDOL
{
    class SedolValidator : ISedolValidator
    {
        public ISedolValidationResult ValidateSedol(string Input)
        {
            try
            {
                if ((Input.ToCharArray().Length != 7) || (String.IsNullOrEmpty(Input)))
                    return new SedolResult { InputString = Input, IsValidSedol = false, IsUserDefined = false, ValidationDetails = validaionResults.Input_string_was_not_7_characters_long.ToString() };

                else if (!Input.All(char.IsLetterOrDigit))
                    return new SedolResult { InputString = Input, IsValidSedol = false, IsUserDefined = false, ValidationDetails = validaionResults.SEDOL_contains_invalid_characters.ToString() };

                else if (validateChecksum(Input))
                    return new SedolResult { InputString = Input, IsValidSedol = true, IsUserDefined = true, ValidationDetails = validaionResults.Valid_SEDOL.ToString() };
                else
                    return new SedolResult { InputString = Input, IsValidSedol = false, IsUserDefined = false, ValidationDetails = validaionResults.Checksum_digit_does_not_agree_with_the_rest_of_the_input.ToString() };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public int validateInputString(string Input)
        {
            try
            {
                if ((Input.ToCharArray().Length != 7) || (String.IsNullOrEmpty(Input)))
                    return (int)validaionResults.Input_string_was_not_7_characters_long;

                else if (!Input.All(char.IsLetterOrDigit))
                    return (int)validaionResults.SEDOL_contains_invalid_characters;
                else
                    return 0;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool validateChecksum(string Input)
        {
            try
            {
                char[] _arr = Input.ToUpper().ToCharArray();
                int[] _str = new int[7];
                for (int i = 0; i < 6; i++)
                {
                    if ((int)_arr[i] >= 65 && (int)_arr[i] <= 90)
                    {
                        _str[i] = ((int)_arr[i] - 65) + 10;
                    }
                    else
                    {
                        _str[i] = _arr[i] - 48;
                    }
                }
                _str[6] = _arr[6] - 48;
                int sum = (_str[0] * 1) + (_str[1] * 3) + (_str[2] * 1) + (_str[3] * 7) + (_str[4] * 3) + (_str[5] * 9);
                int checksumval = (10 - (sum % 10)) % 10;
                if (_str[6] == checksumval)
                    return true;
                else
                    return false;
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public enum validaionResults
        {
            Input_string_was_not_7_characters_long,
            Checksum_digit_does_not_agree_with_the_rest_of_the_input,
            SEDOL_contains_invalid_characters,
            Valid_SEDOL
        }
    }

    class SedolResult : ISedolValidationResult
    {
        private string inputstring;

        private bool isvalidsedol;

        private bool isuserdefined;

        private string validationdetails;

        public string InputString
        {
            get
            {
                return inputstring;
            }
            set
            {
                inputstring = value;
            }
        }
        public bool IsValidSedol
        {
            get
            {
                return isvalidsedol;
            }
            set
            {
                isvalidsedol = value;
            }
        }
        public bool IsUserDefined
        {
            get
            {
                return isuserdefined;
            }
            set
            {
                isuserdefined = value;
            }
        }
        public string ValidationDetails
        {
            get
            {
                return validationdetails;
            }
            set
            {
                validationdetails = value;
            }
        }

    }
}
