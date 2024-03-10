using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Scene.Entity
{
    public interface IGameEntity
    {
        public int EntityID { get; set; }
        public int GroupID { get; set; }
        public Position Position { get; set; }
        public Position Rotation { get; set; }

        public SceneEntityInfo ToProto();
    }
}
