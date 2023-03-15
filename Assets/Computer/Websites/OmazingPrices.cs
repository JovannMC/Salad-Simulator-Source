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
        {"RPX 4090", 1799.99f},
        {"RPX 4080", 1299.99f},
        {"RPX 4070 Ti", 799.99f},
        {"RPX 3090 Ti", 1199.99f},
        {"RPX 3090", 999.99f},
        {"RPX 3080 Ti", 899.99f},
        {"RPX 3080", 799.99f},
        {"RPX 3070 Ti", 599.99f},
        {"RPX 3070", 499.99f},
        {"RPX 3060 Ti", 399.99f},
        {"RPX 3060", 329.99f},
        {"RPX 2080 Ti", 399.99f},
        {"RPX 2080", 349.99f},
        {"RPX 2070", 269.99f},
        {"RPX 2060", 229.99f},
        {"GPX 1660 Ti", 199.99f},
        {"GPX 1660", 169.99f},
        {"GPX 1650 Super", 139.99f},
        {"GPX 1650", 119.99f},
        {"GPX 1080 Ti", 349.99f},
        {"GPX 1080", 299.99f},
        {"GPX 1070 Ti", 249.99f},
        {"GPX 1070", 229.99f},
        {"GPX 1060", 139.99f},
        {"GPX 1050 Ti", 99.99f}

    };
    public static readonly Dictionary<string, int> code = new Dictionary<string, int>()
    {
        {"THISGAMESUCKS", -100},
        {"OMAZING", 10},
        {"SORRY", 20},
        {"JOVANNMC", 100},
    };
}
