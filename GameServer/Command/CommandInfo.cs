namespace EggLink.DanhengServer.Command
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandInfo(string name, string description, string usage, string keyword = "") : Attribute
    {
        public CommandInfo(string name, string description, string usage, List<string> alias, string keyword = "") : this(name, description, usage, keyword)
        {
            Alias = alias ?? [];
        }

        public string Name { get; } = name;
        public string Description { get; } = description;
        public string Usage { get; } = usage;
        public string Keyword { get; } = keyword;
        public List<string> Alias { get; } = [];
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CommandMethod(List<CommandCondition> conditions) : Attribute
    {
        public List<CommandCondition> Conditions { get; } = conditions;
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CommandDefault : Attribute
    {
    }

    public class CommandCondition
    {
        public int Index { get; set; }
        public string ShouldBe { get; set; } = "";
    }
}
