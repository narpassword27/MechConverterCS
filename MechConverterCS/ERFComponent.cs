using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MechConverterCS
{
    public class ERFComponent
    {
        public IEnumerable<Tuple<double, double, double>> Vertices { get; private set; }
        public string FileName { get; }

        public ERFComponent(string filepath)
        {
            FileName = new FileInfo(filepath).Name;
            PopulateVertices(filepath);
        }

        private void PopulateVertices(string filepath)
        {
            using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            using (var stream = new BinaryReader(fs))
            {
                const int byteIndexOfPartCount = 63;
                int ReadIndex = byteIndexOfPartCount;

                byte[] fsBuffer = new byte[10];

                //Need to skip the header
                //fs.Read(fsBuffer, ReadIndex, 1);

                //fs.Position = ReadIndex;

                //var temp = fs.ReadByte();

                //var fsRead = new StreamReader(fs);
                //var temp = fsRead.Read();



            }
        }

        public void Transform(Tuple<double, double, double> transformationMatrix)
        {
            List<Tuple<double, double, double>> newVertices = new List<Tuple<double, double, double>>();

            foreach (var vertex in Vertices)
            {
                newVertices.Add
                    (new Tuple<double, double, double>
                        (
                            vertex.Item1 * transformationMatrix.Item1,
                            vertex.Item2 * transformationMatrix.Item2,
                            vertex.Item3 * transformationMatrix.Item3
                        )
                    );
            }

            Vertices = newVertices;
        }

        private void DecryptERF() => throw new NotImplementedException();
    }
}
