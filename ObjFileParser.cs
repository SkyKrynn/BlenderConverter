using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blender_Converter
{
    class ObjFileParser : IModelFileParser
    {
        private string mFilename;
        private ModelInfo mInfo;
        private ModelData mData;

        public ObjFileParser(String filename)
        {
            mFilename = filename;
            getInfo();
            getData();
        }

        public ModelData getData()
        {
            if (mData != null)
                return mData;

            using (StreamReader reader = new StreamReader(mFilename))
            {
                String buffer;
                mData = new ModelData(getInfo());
                int idxPos = 0;
                int idxTex = 0;
                int idxNor = 0;
                int idxFac = 0;
                while ((buffer = reader.ReadLine()) != null)
                {
                    String[] tokens = buffer.Split(' ');
                    switch (tokens[0])
                    {
                        case "v":
                            mData.Positions[idxPos, 0] = float.Parse(tokens[1]);
                            mData.Positions[idxPos, 1] = float.Parse(tokens[2]);
                            mData.Positions[idxPos, 2] = float.Parse(tokens[3]);
                            idxPos++;
                            break;
                        case "vt":
                            mData.Texels[idxTex, 0] = float.Parse(tokens[1]);
                            mData.Texels[idxTex, 1] = float.Parse(tokens[2]);
                            idxTex++;
                            break;
                        case "vn":
                            mData.Normals[idxNor, 0] = float.Parse(tokens[1]);
                            mData.Normals[idxNor, 1] = float.Parse(tokens[2]);
                            mData.Normals[idxNor, 2] = float.Parse(tokens[3]);
                            idxNor++;
                            break;
                        case "f":
                            String[] index = tokens[1].Split('/');
                            mData.Faces[idxFac, 0] = int.Parse(index[0]);
                            mData.Faces[idxFac, 1] = int.Parse(index[1]);
                            mData.Faces[idxFac, 2] = int.Parse(index[2]);
                            index = tokens[2].Split('/');
                            mData.Faces[idxFac, 3] = int.Parse(index[0]);
                            mData.Faces[idxFac, 4] = int.Parse(index[1]);
                            mData.Faces[idxFac, 5] = int.Parse(index[2]);
                            index = tokens[3].Split('/');
                            mData.Faces[idxFac, 6] = int.Parse(index[0]);
                            mData.Faces[idxFac, 7] = int.Parse(index[1]);
                            mData.Faces[idxFac, 8] = int.Parse(index[2]);
                            idxFac++;
                            break;
                        default:
                            break;
                    }
                }
                return mData;
            }
        }

        public ModelInfo getInfo()
        {
            if (mInfo != null)
                return mInfo;

            try
            {
                using (StreamReader reader = new StreamReader(mFilename))
                {
                    String buffer;
                    mInfo = new ModelInfo(Path.GetFileName(mFilename));
                    while((buffer = reader.ReadLine()) != null)
                    {
                        String[] tokens = buffer.Split(' ');
                        switch(tokens[0])
                        {
                            case "v":
                                mInfo.NumPositions++;
                                break;
                            case "vt":
                                mInfo.NumTexels++;
                                break;
                            case "vn":
                                mInfo.NumNormals++;
                                break;
                            case "f":
                                mInfo.NumFaces++;
                                break;
                            default:
                                break;
                        }
                    }
                    mInfo.NumVertices = mInfo.NumFaces * 3;
                    mInfo.NumColors = 0;
                    return mInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
