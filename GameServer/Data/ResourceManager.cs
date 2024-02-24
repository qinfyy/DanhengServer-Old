using System;
using System.IO;
using System.Reflection;
using EggLink.DanhengServer.Program;
using EggLink.DanhengServer.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EggLink.DanhengServer.Data
{
    internal class ResourceManager
    {
        public static Logger Logger { get; private set; } = new Logger("ResourceManager");
        public static void LoadGameData()
        {
            LoadExcel();
        }

        public static void LoadExcel()
        {
            var classes = Assembly.GetExecutingAssembly().GetTypes();  // Get all classes in the assembly
            foreach (var cls in classes)
            {
                var attribute = (ResourceEntity)Attribute.GetCustomAttribute(cls, typeof(ResourceEntity));

                if (attribute != null)
                {
                    var resource = (ExcelResource)Activator.CreateInstance(cls);
                    var path = EntryPoint.GetConfig().Path.ResourcePath + "/ExcelOutput/" + attribute.FileName;
                    var file = new FileInfo(path);
                    if (!file.Exists)
                    {
                        if (attribute.IsCritical)
                        {
                            throw new FileNotFoundException($"File {path} not found");
                        }
                        else
                        {
                            Logger.Warn($"File {path} not found");
                            continue;
                        }
                    }
                    var json = file.OpenText().ReadToEnd();
                    var count = 0;
                    using (var reader = new JsonTextReader(new StringReader(json)))
                    {
                        reader.Read();
                        if (reader.TokenType == JsonToken.StartArray)
                        {
                            // array
                            var jArray = JArray.Parse(json);
                            foreach (var item in jArray)
                            {
                                var res = JsonConvert.DeserializeObject(item.ToString(), cls);
                                ((ExcelResource)res).Loaded();
                                count++;
                            }
                        }
                        else if (reader.TokenType == JsonToken.StartObject)
                        {
                            // dictionary
                            var jObject = JObject.Parse(json);
                            foreach (var item in jObject)
                            {
                                var id = int.Parse(item.Key);
                                var obj = item.Value;
                                var instance = JsonConvert.DeserializeObject(obj.ToString(), cls);
                                if (instance == null)
                                {
                                    // Deserialize as JObject to handle nested dictionaries
                                    var nestedObject = JsonConvert.DeserializeObject<JObject>(obj.ToString());

                                    // Process only if it's a top-level dictionary, not nested
                                    if (nestedObject.Count > 0 && nestedObject.First.First.Type != JTokenType.Object)
                                    {
                                        ((ExcelResource)instance).Loaded();
                                    }
                                }
                                else
                                {
                                    ((ExcelResource)instance).Loaded();
                                }
                                count++;
                            }
                        }
                    }
                    Logger.Info($"Loaded {count} {cls.Name}s.");
                }
            }
        }

    }
}
