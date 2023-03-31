using System.Collections.Generic;

public static class HardwareCompatibility
{
    // Name, compatible hardware
    public static readonly Dictionary<string, string[]> cpu = new Dictionary<string, string[]>()
    {
        {"Z9-13900k", new string[] {"Z790", "B660"} },
        {"Z9-12900k", new string[] {"Z790", "B660"} },
        {"Z7-13700k", new string[] {"Z790", "B660"} },
        {"Z7-12700k", new string[] {"Z790", "B660"} },
        {"Z5-13600k", new string[] {"Z790", "B660"} },
        {"Z5-12600k", new string[] {"Z790", "B660"} },
        {"Z3-13100f", new string[] {"Z790", "B660"} },
        {"Z3-12100f", new string[] {"Z790", "B660"} },
        {"Z7-9700k", new string[] {"B360", "B260"} },
        {"Z7-7700k", new string[] {"B360", "B260"} },
        {"Z3-7100", new string[] {"B360", "B260"} },
        {"Plerium G6000", new string[] {"Z790", "B660", "B460"} },
        {"Plerium G5000", new string[] {"Z790", "B660", "B460"} },
        {"Celerium G5000", new string[] {"Z790", "B660", "B460"} },
        {"Celerium G4000", new string[] {"Z790", "B660", "B460"} },
    };

    public static readonly Dictionary<string, string[]> ram = new Dictionary<string, string[]>()
    {

    };

    public static readonly Dictionary<string, string[]> gpu = new Dictionary<string, string[]>()
    {

    };

    public static readonly Dictionary<string, string[]> psu = new Dictionary<string, string[]>()
    {

    };

    public static readonly Dictionary<string, string[]> storage = new Dictionary<string, string[]>()
    {

    };

    public static readonly Dictionary<string, string[]> cooling = new Dictionary<string, string[]>()
    {

    };

    public static readonly Dictionary<string, string[]> pcCase = new Dictionary<string, string[]>()
    {

    };
}
