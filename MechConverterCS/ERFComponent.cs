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
            PopulateVectors(filepath);
        }

        private void PopulateVectors(string filepath)
        {

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
