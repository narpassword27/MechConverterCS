using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Media3D;

namespace MechConverterCS
{
    public class ERFComponent
    {
        public IEnumerable<Facet> Facets { get; private set; }
        public string FileName { get; }


        public ERFComponent(string filepath)
        {
            FileName = new FileInfo(filepath).Name;
            PopulateFacets(filepath);
        }

        private void PopulateFacets(string filepath)
        {
            int lods = 1;// ERFViewHandler.GetLOD(filepath);
            int meshes = ERFViewHandler.GetNumOfMesh(filepath, lods);
            int numVerts = ERFViewHandler.GetNumOfVert(filepath, lods, meshes);
            var verts = ERFViewHandler.GetVert(filepath, lods, meshes);

            int numIndices = ERFViewHandler.GetNumOfIndexes(filepath, lods, meshes);
            var indices = ERFViewHandler.GetIndexs(filepath, lods, meshes);

            Facet[] facets = new Facet[numIndices];
            for(int i=0; i<numIndices; i++)
            {
                facets[i] = new Facet
                (
                    new Vector3D(verts[(int)indices[i, 0], 0], verts[(int)indices[i, 0], 1], verts[(int)indices[i, 0], 2]),
                    new Vector3D(verts[(int)indices[i, 1], 0], verts[(int)indices[i, 1], 1], verts[(int)indices[i, 1], 2]),
                    new Vector3D(verts[(int)indices[i, 2], 0], verts[(int)indices[i, 2], 1], verts[(int)indices[i, 2], 2])
                    //new Tuple<float, float, float>(0f, 0f, 0f)
                );
            }

            this.Facets = facets;
        }

        private void DecryptERF() => throw new NotImplementedException();
    }
}
