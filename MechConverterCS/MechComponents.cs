using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IxMilia.Stl;

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
                .Where(fInfo => !fInfo.Name.Contains("cage") && !fInfo.Name.Contains("running"))
                .Select(fInfo => new ERFComponent(fInfo.FullName))
                .ToList();
        }
        public void OutputSTL(string filepath)
        {
            StlFile stlFile = new StlFile();
            stlFile.SolidName = "testsolid";

            foreach (var erf in erfs)
            {
                foreach (var facet in erf.Facets)
                {
                    stlFile.Triangles.Add
                        (
                            new StlTriangle
                            (
                                new StlNormal((float)facet.Normal.X, (float)facet.Normal.Y, (float)facet.Normal.Z),
                                new StlVertex((float)facet.Vertex1.X, (float)facet.Vertex1.Y, (float)facet.Vertex1.Z),
                                new StlVertex((float)facet.Vertex2.X, (float)facet.Vertex2.Y, (float)facet.Vertex2.Z),
                                new StlVertex((float)facet.Vertex3.X, (float)facet.Vertex3.Y, (float)facet.Vertex3.Z)
                            )
                        );
                }
            }

            stlFile.Save(new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None), false);
        }

        public void OutputSTL2(string filepath)
        {
            using (var fs = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var bw = new BinaryWriter(fs))
            {
                UInt32 facetcount = 0;
                byte[] header = new byte[80];
                bw.Write(header);
                bw.Flush();
                bw.Seek(4, SeekOrigin.Current);
                bw.Flush();

                foreach (var erf in erfs.Take(1))
                {
                    foreach (var facet in erf.Facets)
                    {
                        bw.Write(facet.Normal.X);
                        bw.Write(facet.Normal.Y);
                        bw.Write(facet.Normal.Z);

                        bw.Write(facet.Vertex1.X);
                        bw.Write(facet.Vertex1.Y);
                        bw.Write(facet.Vertex1.Z);

                        bw.Write(facet.Vertex2.X);
                        bw.Write(facet.Vertex2.Y);
                        bw.Write(facet.Vertex2.Z);

                        bw.Write(facet.Vertex3.X);
                        bw.Write(facet.Vertex3.Y);
                        bw.Write(facet.Vertex3.Z);

                        bw.Write(new byte[2]);

                        facetcount++;
                    }
                }





                bw.Flush();
                bw.Seek(80, SeekOrigin.Begin);
                bw.Write(facetcount);
                bw.Flush();
            }
        }
    }
}
