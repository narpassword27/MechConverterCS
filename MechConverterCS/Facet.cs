using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechConverterCS
{
    public struct Facet
    {
        public readonly Tuple<double, double, double> Vertex1;
        public readonly Tuple<double, double, double> Vertex2;
        public readonly Tuple<double, double, double> Vertex3;
        //public SOMETHING NormalVector

        public Facet(Tuple<double, double, double> Vertex1, Tuple<double, double, double> Vertex2, Tuple<double, double, double> Vertex3)//, SOMETHING NormalVector)
        {
            this.Vertex1 = Vertex1;
            this.Vertex2 = Vertex2;
            this.Vertex3 = Vertex3;
        }
    }
}
