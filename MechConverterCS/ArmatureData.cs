using System;
using System.Collections.Generic;
using System.IO;
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
            using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var br = new BinaryReader(fs))
            {
                byte[] header = br.ReadBytes(147);


                List<Joint> temp = new List<Joint>();


                //components seem to start at byte 147, each is 82 bytes long
                //dunno data yet
                while (fs.Position != fs.Length)
                {
                    string partName = "";
                    while (br.PeekChar() != 0)
                    {
                        partName += br.ReadChar();
                    }
                    byte[] data = br.ReadBytes(82 - partName.Length);

                    temp.Add(new Joint(partName, data));

                }

                var temps = 0;






            }
        }
    }

    public struct Joint
    {
        public string JointName;
        public byte[] Bytes;

        public Joint(string JointName, byte[] Bytes)
        {
            this.JointName = JointName;
            this.Bytes = Bytes;
        }
    }
}
