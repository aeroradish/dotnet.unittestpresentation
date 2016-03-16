using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.UnitTesting.Logic;

namespace DotNet.UnitTesting.Logic
{
    public class FileExtensionManager : IFileExtensionManager
    {
        public bool IsValid(string fileName)
        {
            //read some file here
            if (fileName.EndsWith(".foo"))
            {
                return false;
            }
            return true;
        }
    }
}
