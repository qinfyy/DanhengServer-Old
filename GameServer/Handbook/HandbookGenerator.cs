using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Program;
using EggLink.DanhengServer.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Handbook
{
    public static class HandbookGenerator
    {
        public static readonly string HandbookPath = "Config/Handbook.txt";

        public static void Generate()
        {
            var config = ConfigManager.Config;
            var textMapPath = config.Path.ResourcePath + "/TextMap/TextMap" + config.ServerOption.Language + ".json";
            if (!File.Exists(textMapPath))
            {
                Logger.GetByClassName().Error("TextMap file not found: " + textMapPath);
                return;
            }
            var textMap = JsonConvert.DeserializeObject<Dictionary<long, string>>(File.ReadAllText(textMapPath));

            if (textMap == null)
            {
                Logger.GetByClassName().Error("Failed to load TextMap file: " + textMapPath);
                return;
            }

            var builder = new StringBuilder();
            builder.AppendLine("Handbook generated in " + DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            GenerateCmd(builder);

            builder.AppendLine();
            builder.AppendLine("#Avatar");
            builder.AppendLine();
            GenerateAvatar(builder, textMap);

            builder.AppendLine();
            builder.AppendLine("#Item");
            builder.AppendLine();
            GenerateItem(builder, textMap);

            builder.AppendLine();
            builder.AppendLine("#MainMission");
            builder.AppendLine();
            GenerateMainMissionId(builder, textMap);

            builder.AppendLine();
            builder.AppendLine("#SubMission");
            builder.AppendLine();
            GenerateSubMissionId(builder, textMap);

            builder.AppendLine();
            builder.AppendLine("#RogueBuff");
            builder.AppendLine();
            GenerateRogueBuff(builder, textMap);

            builder.AppendLine();
            builder.AppendLine("#RogueMiracle");
            builder.AppendLine();
            GenerateRogueMiracleDisplay(builder, textMap);

            builder.AppendLine();
            WriteToFile(builder.ToString());

            Logger.GetByClassName().Info("Handbook generated successfully.");
        }

        public static void GenerateCmd(StringBuilder builder)
        {
            foreach (var cmd in EntryPoint.CommandManager.CommandInfo)
            {
                builder.Append("Command: " + cmd.Key);
                builder.Append(" --- Description: " + cmd.Value.Description);
                builder.Append(" --- Usage: " + cmd.Value.Usage);
                builder.AppendLine();
            }
        }

        public static void GenerateItem(StringBuilder builder, Dictionary<long, string> map)
        {
            foreach (var item in GameData.ItemConfigData.Values)
            {
                var name = map.TryGetValue(item.ItemName.Hash, out var value) ? value : $"[{item.ItemName.Hash}]";
                builder.AppendLine(item.ID + ": " + name);
            }
        }

        public static void GenerateAvatar(StringBuilder builder, Dictionary<long, string> map)
        {
            foreach (var avatar in GameData.AvatarConfigData.Values)
            {
                var name = map.TryGetValue(avatar.AvatarName.Hash, out var value) ? value : $"[{avatar.AvatarName.Hash}]";
                builder.AppendLine(avatar.AvatarID + ": " + name);
            }
        }

        public static void GenerateMainMissionId(StringBuilder builder, Dictionary<long, string> map)
        {
            foreach (var mission in GameData.MainMissionData.Values)
            {
                var name = map.TryGetValue(mission.Name.Hash, out var value) ? value : $"[{mission.Name.Hash}]";
                builder.AppendLine(mission.MainMissionID + ": " + name);
            }
        }

        public static void GenerateSubMissionId(StringBuilder builder, Dictionary<long, string> map)
        {
            foreach (var mission in GameData.SubMissionData.Values)
            {
                var name = map.TryGetValue(mission.TargetText.Hash, out var value) ? value : $"[{mission.TargetText.Hash}]";
                builder.AppendLine(mission.SubMissionID + ": " + name);
            }
        }

        public static void GenerateRogueBuff(StringBuilder builder, Dictionary<long, string> map)
        {
            foreach (var buff in GameData.RogueMazeBuffData)
            {
                var name = map.TryGetValue(buff.Value.BuffName.Hash, out var value) ? value : $"[{buff.Value.BuffName.Hash}]";
                builder.AppendLine(buff.Key + ": " + name + " --- Level:" + buff.Value.Lv);
            }
        }

        public static void GenerateRogueMiracleDisplay(StringBuilder builder, Dictionary<long, string> map)
        {
            foreach (var display in GameData.RogueMiracleDisplayData.Values)
            {
                var name = map.TryGetValue(display.MiracleName.Hash, out var value) ? value : $"[{display.MiracleName.Hash}]";
                builder.AppendLine(display.MiracleDisplayID + ": " + name);
            }
        }

        public static void WriteToFile(string content)
        {
            File.WriteAllText(HandbookPath, content);
        }
    }
}
