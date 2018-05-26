using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechConverterCS
{
    public class ArmatureData
    {
        public enum ArmatureMode { Standing }
        public Dictionary<string, Tuple<double, double, double>> TransformationMatrices { get; }

        public ArmatureData(string filepath, ArmatureMode mode)
        {

        }
    }
}
