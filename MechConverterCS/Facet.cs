using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace MechConverterCS
{
    public struct Facet
    {
        public readonly Vector3D Vertex1;
        public readonly Vector3D Vertex2;
        public readonly Vector3D Vertex3;
        public readonly Vector3D Normal;

        public Facet(Vector3D Vertex1, Vector3D Vertex2, Vector3D Vertex3, Vector3D Normal)
        {
            this.Vertex1 = Vertex1;
            this.Vertex2 = Vertex2;
            this.Vertex3 = Vertex3;
            this.Normal = Normal;
        }

        public Facet(Vector3D Vertex1, Vector3D Vertex2, Vector3D Vertex3)
        {
            this.Vertex1 = Vertex1;
            this.Vertex2 = Vertex2;
            this.Vertex3 = Vertex3;

            this.Normal = Vector3D.CrossProduct(Vertex2 - Vertex1, Vertex3 - Vertex1);
            this.Normal.Normalize();
        }
    }
}
