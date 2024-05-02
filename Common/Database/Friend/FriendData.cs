using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Database.Friend
{
    [SugarTable("Friend")]
    public class FriendData : BaseDatabaseData
    {
        [SugarColumn(IsJson = true)]
        public List<int> FriendList { get; set; } = [];

        [SugarColumn(IsJson = true)]
        public List<int> BlackList { get; set; } = [];

        [SugarColumn(IsJson = true)]
        public List<int> SendApplyList { get; set; } = [];

        [SugarColumn(IsJson = true)]
        public List<int> ReceiveApplyList { get; set; } = [];
    }
}
