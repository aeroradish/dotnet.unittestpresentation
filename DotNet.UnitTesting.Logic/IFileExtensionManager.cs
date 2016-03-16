using System;
namespace DotNet.UnitTesting.Logic
{
    public interface IFileExtensionManager
    {
        bool IsValid(string fileName);
    }
}
