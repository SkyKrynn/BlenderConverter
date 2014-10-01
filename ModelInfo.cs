using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blender_Converter
{
    class ModelInfo
    {
        public ModelInfo(String filename)
        {
            OriginalFileName = filename;
        }

        public int NumVertices { get; set; }
        public int NumPositions { get; set; }
        public int NumTexels { get; set; }
        public int NumColors { get; set; }
        public int NumNormals { get; set; }
        public int NumFaces { get; set; }
        public string OriginalFileName { get; private set; }
    }
}
