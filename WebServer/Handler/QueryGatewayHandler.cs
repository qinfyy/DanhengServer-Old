using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using Google.Protobuf;

namespace EggLink.DanhengServer.Server.Http.Handler
{
    internal class QueryGatewayHandler
    {
        public static Logger Logger = new("GatewayServer");
        public string Data;
        public QueryGatewayHandler()
        {
            var config = ConfigManager.Config;
            var urlData = config.DownloadUrl;

            // build gateway proto
            var gateServer = new Gateserver() {
                RegionName = config.GameServer.GameServerId,
                Ip = config.GameServer.PublicAddress,
                Port = (uint)config.GameServer.PublicPort,
                Msg = "Access verification failed. Please check if you have logged in to the correct account and server.",
                Unk1 = true,
                Unk2 = true,
                Unk3 = true,
                Unk4 = true,
                Unk5 = true
            };

            if (urlData.AssetBundleUrl != null)
            {
                gateServer.AssetBundleUrl = urlData.AssetBundleUrl;
            }

            if (urlData.ExResourceUrl != null)
            {
                gateServer.ExResourceUrl = urlData.ExResourceUrl;
            }

            if (urlData.LuaUrl != null)
            {
                gateServer.LuaUrl = urlData.LuaUrl;
                gateServer.MdkResVersion = urlData.LuaUrl.Split('/')[urlData.LuaUrl.Split('/').Length - 1].Split('_')[1];
            }
            
            if (urlData.IfixUrl != null)
            {
                gateServer.IfixUrl = urlData.IfixUrl;
                gateServer.IfixVersion = urlData.IfixUrl.Split('/')[urlData.IfixUrl.Split('/').Length - 1].Split('_')[1];
            }
            Logger.Info("Client request: query_gateway");

            Data = Convert.ToBase64String(gateServer.ToByteArray());
        }
    }
}
