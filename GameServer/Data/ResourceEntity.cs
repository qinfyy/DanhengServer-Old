using System;

namespace EggLink.DanhengServer.Data
{

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    internal class ResourceEntity : Attribute
    {
        public string FileName { get; private set; }
        public bool IsCritical { get; private set; }  // If the resource is critical, the server will not start if it is not found

        public ResourceEntity(string fileName, bool isCritical = false)
        {
            FileName = fileName;
            IsCritical = isCritical;
        }
    }
}
