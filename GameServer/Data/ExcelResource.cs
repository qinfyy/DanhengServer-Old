using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Data
{
    internal abstract class ExcelResource
    {
        public abstract int GetId();

        public virtual void Loaded()
        {
        }

        public virtual void Finalized()
        {
        }
    }
}
