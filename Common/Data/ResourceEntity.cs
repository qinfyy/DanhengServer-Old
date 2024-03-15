using System;

namespace EggLink.DanhengServer.Data
{

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    internal class ResourceEntity : Attribute
    {
        public List<string> FileName { get; private set; }
        public bool IsCritical { get; private set; }  // If the resource is critical, the server will not start if it is not found

        public ResourceEntity(string fileName, bool isCritical = false, bool isMultifile = false)
        {
            if (isMultifile)
            {
                FileName = new List<string>(fileName.Split(','));
            }
            else
                FileName = [fileName];
            IsCritical = isCritical;
        }
    }
}
