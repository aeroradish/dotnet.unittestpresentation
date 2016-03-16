using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UnitTesting.Logic
{
    public class AlwaysValidFakeExtensionManager : IFileExtensionManager
    {
        //Stub for use in Dependency injection
        public bool IsValid(string fileName)
        {
            return true;
        }
    }
}
