using System;
using System.Linq;

namespace SEDOL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SedolValidator result = new SedolValidator();
                var output = result.ValidateSedol("B0YBKJ7");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }

   
}
