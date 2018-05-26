using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechConverterCS
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new MechComponents(@"F:\Mercs\textures.Files\mechs\thor", @"F:\Mercs\core.Files\mechs\thor\thor.data{hierarchicalobb}");
        }
    }
}
