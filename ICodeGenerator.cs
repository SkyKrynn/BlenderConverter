﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blender_Converter
{
    interface ICodeGenerator
    {
        void CreateCode(String dir, String basefilename);
    }
}
