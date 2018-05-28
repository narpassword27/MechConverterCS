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
            int lods = ERFViewHandler.GetLOD(filepath);
            int meshes = ERFViewHandler.GetNumOfMesh(filepath, lods);
            int temp = ERFViewHandler.GetNumOfVert(filepath, lods, meshes);
            var verts = ERFViewHandler.GetVert(filepath, lods, meshes);

        }

        private void DecryptERF() => throw new NotImplementedException();
    }
}
