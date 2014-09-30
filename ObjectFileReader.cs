using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blender_Converter
{
    class ObjectFileReader
    {
        private string mFilename;
        private ModelInfo mInfo;
        private ModelData mData;

        public int Vertices { get { return mInfo.Vertices; } }
        public int Positions { get { return mInfo.Positions; } }
        public int Texels { get { return mInfo.Texels; } }
        public int Normals { get { return mInfo.Normals; } }
        public int Faces { get { return mInfo.Faces; } }
        public ModelInfo Info { get { return mInfo; } }
        public ModelData Data { get { return mData; } }


        public ObjectFileReader(String filename)
        {
            mFilename = filename;
            mInfo = getInfo();
            mInfo.OriginalFileName = Path.GetFileName(filename);
            mData = getData(mInfo);
        }

        private ModelData getData(ModelInfo info)
        {
            try
            {
                using (StreamReader reader = new StreamReader(mFilename))
                {
                    String buffer;
                    ModelData data = new ModelData(info);
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
                                data.Positions[idxPos, 0] = float.Parse(tokens[1]);
                                data.Positions[idxPos, 1] = float.Parse(tokens[2]);
                                data.Positions[idxPos, 2] = float.Parse(tokens[3]);
                                idxPos++;
                                break;
                            case "vt":
                                data.Texels[idxTex, 0] = float.Parse(tokens[1]);
                                data.Texels[idxTex, 1] = float.Parse(tokens[2]);
                                idxTex++;
                                break;
                            case "vn":
                                data.Normals[idxNor, 0] = float.Parse(tokens[1]);
                                data.Normals[idxNor, 1] = float.Parse(tokens[2]);
                                data.Normals[idxNor, 2] = float.Parse(tokens[3]);
                                idxNor++;
                                break;
                            case "f":
                                String[] index = tokens[1].Split('/');
                                data.Faces[idxFac, 0] = int.Parse(index[0]);
                                data.Faces[idxFac, 1] = int.Parse(index[1]);
                                data.Faces[idxFac, 2] = int.Parse(index[2]);
                                index = tokens[2].Split('/');
                                data.Faces[idxFac, 3] = int.Parse(index[0]);
                                data.Faces[idxFac, 4] = int.Parse(index[1]);
                                data.Faces[idxFac, 5] = int.Parse(index[2]);
                                index = tokens[3].Split('/');
                                data.Faces[idxFac, 6] = int.Parse(index[0]);
                                data.Faces[idxFac, 7] = int.Parse(index[1]);
                                data.Faces[idxFac, 8] = int.Parse(index[2]);
                                idxFac++;
                                break;
                            default:
                                break;
                        }
                    }
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ModelInfo getInfo()
        {
            try
            {
                using (StreamReader reader = new StreamReader(mFilename))
                {
                    String buffer;
                    ModelInfo info = new ModelInfo();
                    while((buffer = reader.ReadLine()) != null)
                    {
                        String[] tokens = buffer.Split(' ');
                        switch(tokens[0])
                        {
                            case "v":
                                info.Positions++;
                                break;
                            case "vt":
                                info.Texels++;
                                break;
                            case "vn":
                                info.Normals++;
                                break;
                            case "f":
                                info.Faces++;
                                break;
                            default:
                                break;
                        }
                    }
                    return info;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
