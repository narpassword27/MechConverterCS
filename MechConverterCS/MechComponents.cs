using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MechConverterCS
{
    public class MechComponents
    {
        private ArmatureData armatureData;
        private IEnumerable<ERFComponent> erfs;

        public MechComponents(string erfDirectory, string armatureFilePath, ArmatureData.ArmatureMode pose = ArmatureData.ArmatureMode.Standing)
        {
            armatureData = new ArmatureData(armatureFilePath, pose);

            erfs = new DirectoryInfo(erfDirectory)
                .GetFiles("*.erf")
                .Select(fInfo => new ERFComponent(fInfo.FullName))
                .ToList();
        }

        public IEnumerable<Tuple<double, double, double>> OutputMesh()
        {
            foreach (var erf in erfs)
            {
                erf.Transform(armatureData.TransformationMatrices[erf.FileName]);

                foreach(var vector in erf.Vertices)
                    yield return vector;
            }
        }
    }
}
