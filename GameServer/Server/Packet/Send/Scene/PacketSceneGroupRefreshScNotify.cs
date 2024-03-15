using EggLink.DanhengServer.Game.Scene.Entity;
using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Send.Scene
{
    public class PacketSceneGroupRefreshScNotify : BasePacket
    {
        public PacketSceneGroupRefreshScNotify(List<IGameEntity> entity, bool isAdd = true) : base(CmdIds.SceneGroupRefreshScNotify)
        {
            var proto = new SceneGroupRefreshScNotify();
            Dictionary<int, GroupRefreshInfo> refreshInfo = [];
            foreach (var e in entity)
            {
                var group = new GroupRefreshInfo()
                {
                    GroupId = (uint)e.GroupID
                };
                if (isAdd)
                {
                    group.RefreshEntity.Add(new SceneEntityRefreshInfo()
                    {
                        AddEntity = e.ToProto()
                    });
                }
                else
                {
                    group.RefreshEntity.Add(new SceneEntityRefreshInfo()
                    {
                        DelEntity = (uint)e.EntityID
                    });
                }

                if (refreshInfo.TryGetValue(e.GroupID, out GroupRefreshInfo? value))
                {
                    value.RefreshEntity.AddRange(group.RefreshEntity);
                }
                else
                {
                    refreshInfo[e.GroupID] = group;
                }
            }

            proto.GroupRefreshList.AddRange(refreshInfo.Values);

            SetData(proto);
        }

        public PacketSceneGroupRefreshScNotify(IGameEntity entity, bool isAdd = true) : base(CmdIds.SceneGroupRefreshScNotify)
        {
            var proto = new SceneGroupRefreshScNotify();
            var group = new GroupRefreshInfo();
            if (isAdd)
            {
                group.RefreshEntity.Add(new SceneEntityRefreshInfo()
                {
                    AddEntity = entity.ToProto()
                });
            }
            else
            {
                group.RefreshEntity.Add(new SceneEntityRefreshInfo()
                {
                    DelEntity = (uint)entity.EntityID
                });
            }
            group.GroupId = (uint)entity.GroupID;
            proto.GroupRefreshList.Add(group);

            SetData(proto);
        }
    }
}
