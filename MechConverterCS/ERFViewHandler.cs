using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace MechConverterCS
{
    public static class ERFViewHandler
    {
        private static dynamic Viewer;

        static ERFViewHandler()
        {
            var dir2 = Directory.GetCurrentDirectory() + "\\";
            var viewer = Assembly.LoadFile($"{dir2}ERFViewer.dll");
            Viewer = Activator.CreateInstance(viewer.GetExportedTypes()[0]);
        }


        /// <summary>
        /// returns the Number of LOD (Levels of Detail).
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static int GetLOD(string fileName) => Viewer.GetLOD(fileName);

        /// <summary>
        /// returns the number of models in the level requested.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static int GetNumOfMesh(string fileName, int lod) => Viewer.GetNumOfMesh(fileName, lod);

        /// <summary>
        /// returns the number of Verties in the model in the level requested.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lod"></param>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static int GetNumOfVert(string fileName, int lod, int mesh) => Viewer.GetNumOfVert(fileName, lod, mesh);

        /// <summary>
        /// returns the vertices in a 3 index array (x,y,Z)-> in the model/level
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lod"></param>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static float[,] GetVert(string fileName, int lod, int mesh) => Viewer.GetVert(fileName, lod, mesh);

        /// <summary>
        /// returns the UV points in a 2 index arrary (u,V) -> in the model/level
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lod"></param>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static float[,] GetUV(string fileName, int lod, int mesh) => Viewer.GetUV(fileName, lod, mesh);

        /// <summary>
        /// returns the number of vert indexes in the file (Note: this number has been /3)
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lod"></param>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static int GetNumOfIndexes(string fileName, int lod, int mesh) => Viewer.GetNumOfIndexes(fileName, lod, mesh);

        /// <summary>
        /// returns the Indexs in a 3 index array(1st,2nd,3rd)
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lod"></param>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static float[,] GetIndexs(string fileName, int lod, int mesh) => Viewer.GetIndexs(fileName, lod, mesh);

        /// <summary>
        /// returns the plane points in a 4 index arrary (1,2,3,4)
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lod"></param>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static float[,] GetPlanePoints(string fileName, int lod, int mesh) => Viewer.GetPlanePoints(fileName, lod, mesh);

        /// <summary>
        /// returns the normals in a 3 index arrary (x,y,z)
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lod"></param>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static float[,] GetNormalPoints(string fileName, int lod, int mesh) => Viewer.GetNormalPoints(fileName, lod, mesh);

        /// <summary>
        /// returns the header data for the file in an array
        ///<para/>Array[0] = usually 14
        ///<para/>Array[1] = usually 144 
        ///<para/>Array[2] = usually 5
        ///<para/>Array[3] = X Parent point
        ///<para/>Array[4] = Y Parent Point
        ///<para/>Array[5] = Z Parent Point
        ///<para/>Array[6] = Vector value of Parent points
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static float[] GetHeader(string fileName) => Viewer.GetHeader(fileName);

        /// <summary>
        /// returns the Minimum and max distance in the level of detail
        ///<para/>Array[0] = Minimum distance
        ///<para/>Array[1] = Max distance
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static float[] GetMinMaxDist(string fileName, int lod) => Viewer.GetMinMaxDist(fileName, lod);
    }
}
