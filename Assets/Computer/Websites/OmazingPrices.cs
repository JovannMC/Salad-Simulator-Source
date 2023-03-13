using System.Collections.Generic;

public static class OmazingPrices
{
    public static readonly Dictionary<string, float> price = new Dictionary<string, float>()
    {
        // CPUs
        {"Z9-13900k", 579.99f},
        {"Z9-12900k", 429.99f},
        {"Z7-13700k", 379.99f},
        {"Z7-12700k", 309.99f},
        {"Z5-13600k", 299.99f},
        {"Z5-12600k", 239.99f},
        {"Z3-13100f", 119.99f},
        {"Z3-12100f", 99.99f},
        {"Z7-9700k", 319.99f},
        {"Z7-7700k", 289.99f},
        {"Z3-7100", 86.99f},
        {"Plerium G6000", 69.99f},
        {"Plerium G5000", 58.99f},
        {"Celerium G5000", 48.99f},
        {"Celerium G4000", 39.99f},

        // GPUs
        {"GPX 4090", 1599.99f}
    };
    public static readonly Dictionary<string, int> code = new Dictionary<string, int>()
    {
        {"THISGAMESUCKS", -100},
        {"OMAZING", 10},
        {"SORRY", 20},
        {"JOVANNMC", 100},
    };
}
