using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blender_Converter
{
    public class JavaOptions
    {
        private String mPackage;
        public String Package 
        { 
            get { return mPackage; } 
            set
            {
                value.Trim();
                if (value.Length == 0) return;
                if (value.Contains(' ')) return;
                mPackage = value;
            }
        }

        private String mClassName;
        public String ClassName 
        {
            get { return mClassName; }
            set
            {
                value.Trim();
                if (value.Length == 0) return;
                if (value.Contains(' ')) return;
                mClassName = value;
            }
        }

        public JavaOptions(String package, String classname)
        {
            Package = package;
            ClassName = classname;
        }
    }
}
