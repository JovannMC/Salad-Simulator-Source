using System.Collections.Generic;

public static class Hardware
{
    // Name, Hardware Power, TDP
    public static readonly Dictionary<string, float[]> cpu = new Dictionary<string, float[]>()
    {
        {"Z9-13900k", new float[] {2.0f, 253.0f}},
        {"Z9-12900k", new float[] {1.85f, 241.0f}},
        {"Z7-13700k", new float[] {1.3f, 253.0f}},
        {"Z7-12700k", new float[] {1f, 190.0f}},
        {"Z5-13600k", new float[] {0.88f, 181.0f}},
        {"Z5-12600k", new float[] {0.84f, 125.0f}},
        {"Z3-13100f", new float[] {0.69f, 58.0f}},
        {"Z3-12100f", new float[] {0.73f, 58.0f}},
        {"Z7-9700k", new float[] {0.94f, 95.0f}},
        {"Z7-7700k", new float[] {0.89f, 90.0f}},
        {"Z3-7100", new float[] {0.6f, 50.0f}},
        {"Plerium G6000", new float[] {0.45f, 20.0f}},
        {"Plerium G5000", new float[] {0.4f, 20.0f}},
        {"Celerium G5000", new float[] {0.35f, 15.0f}},
        {"Celerium G4000", new float[] {0.3f, 15.0f}},
    };

    // Name, Hardware Power, TDP
    public static readonly Dictionary<string, float[]> ram = new Dictionary<string, float[]>()
    {
        {"1x4GB DDR4", new float[] {9.99f}},
        {"2x4GB DDR4", new float[] {19.98f}},
        {"1x8GB DDR4", new float[] {19.98f}},
        {"2x8GB DDR4", new float[] {39.96f}},
        {"1x16GB DDR4", new float[] {39.96f}},
        {"2x16GB DDR4", new float[] {79.92f}},
        {"1x32GB DDR4", new float[] {79.92f}},
        {"2x32GB DDR4", new float[] {159.84f}},
        {"1x64GB DDR4", new float[] {159.84f}},
        {"4x32GB DDR4", new float[] {639.36f}},
    };

    // Name, Hardware Power, TDP
    public static readonly Dictionary<string, float[]> gpu = new Dictionary<string, float[]>()
    {
        {"RPX 4090", new float[] { 6.0f, 450.0f } },
        {"RPX 4080", new float[] { 5.5f, 320.0f } },
        {"RPX 4070 Ti", new float[] { 5.2f, 285.0f } },
        {"RPX 3090 Ti", new float[] { 4.8f, 450.0f } },
        {"RPX 3090", new float[] { 4.5f, 350.0f } },
        {"RPX 3080 Ti", new float[] { 4.2f, 350.0f } },
        {"RPX 3080", new float[] { 4.0f, 400.0f } },
        {"RPX 3070 Ti", new float[] { 3.8f, 290.0f } },
        {"RPX 3070", new float[] { 3.5f, 220.0f } },
        {"RPX 3060 Ti", new float[] { 3.2f, 200.0f } },
        {"RPX 3060", new float[] { 3.0f, 170.0f } },
        {"RPX 2080 Ti", new float[] { 3.4f, 250.0f } },
        {"RPX 2080", new float[] { 3.2f, 215.0f } },
        {"RPX 2070", new float[] { 2.91f, 175.0f } },
        {"RPX 2060", new float[] { 2.59f, 160.0f } },
        {"GPX 1660 Ti", new float[] { 2.3f, 125.0f } },
        {"GPX 1660", new float[] { 2.15f, 120.0f } },
        {"GPX 1650 Super", new float[] { 1.85f, 100.0f } },
        {"GPX 1650", new float[] { 1.75f, 75.0f } },
        {"GPX 1080 Ti", new float[] { 2.73f, 250.0f } },
        {"GPX 1080", new float[] { 2.34f, 180.0f } },
        {"GPX 1070 Ti", new float[] { 2.2f, 180.0f } },
        {"GPX 1070", new float[] { 2.05f, 150.0f } },
        {"GPX 1060", new float[] { 1.5f, 120.0f } },
        {"GPX 1050 Ti", new float[] { 1.3f, 75.0f } }
    };

    // Name, Hardware Power, TDP
    public static readonly Dictionary<string, float[]> mobo = new Dictionary<string, float[]>
    {
        {"Omazing Z790", new float[] {0.0f} },
        {"Omazing Z590", new float[] {0.0f} },
        {"Omazing B660", new float[] {0.0f} },
        {"Omazing B460", new float[] {0.0f} },
        {"Omazing B360", new float[] {0.0f} },
        {"Omazing B260", new float[] {0.0f} },
    };

    // Name, Hardware Power, TDP
    public static readonly Dictionary<string, float[]> psu = new Dictionary<string, float[]>
    {
        {"Omazing 300w", new float[] {0.0f} },
        {"Omazing 500w", new float[] {0.0f} },
        {"Omazing 750w", new float[] {0.0f} },
        {"Omazing 800w", new float[] {0.0f} },
        {"Omazing 1000w", new float[] {0.0f} },
        {"Omazing 1500w", new float[] {0.0f} },
    };

    // Name, Hardware Power, TDP
    public static readonly Dictionary<string, float[]> storage = new Dictionary<string, float[]>
    {
        {"500GB SSD", new float[] {0.0f} },
        {"1TB SSD", new float[] {0.0f} },
        {"2TB SSD", new float[] {0.0f} },
        {"1TB HDD", new float[] {0.0f} },
        {"2TB HDD", new float[] {0.0f} },
        {"4TB HDD", new float[] {0.0f} },
        {"8TB HDD", new float[] {0.0f} },
    };

    // Name, Hardware Power, TDP
    public static readonly Dictionary<string, float[]> cooling = new Dictionary<string, float[]>
    {
        {"Omazing 1x120mm", new float[] {0.0f} },
        {"Omazing 2x120mm", new float[] {0.0f} },
        {"Omazing 3x120mm", new float[] {0.0f} },
        {"Omazing 6x120mm", new float[] {0.0f} },
    };

    // Name, Hardware Power, TDP
    public static readonly Dictionary<string, float[]> pcCase = new Dictionary<string, float[]>
    {
        {"Omazing M-ATX", new float[] {0.0f} },
        {"Omazing ATX", new float[] {0.0f} },
        {"Omazing E-ATX", new float[] {0.0f} },
    };

    // Omazing
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

        // RAM
        {"1x4GB DDR4", 9.99f},
        {"2x4GB DDR4", 24.99f},
        {"1x8GB DDR4", 24.99f},
        {"2x8GB DDR4", 44.99f},
        {"1x16GB DDR4", 49.99f},
        {"2x16GB DDR4", 89.99f},
        {"1x32GB DDR4", 89.99f},
        {"2x32GB DDR4", 149.99f},
        {"1x64GB DDR4", 149.99f},
        {"4x32GB DDR4", 299.99f},

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
        {"GPX 1050 Ti", 99.99f},

        // Motherboard
        {"Omazing Z790", 229.99f},
        {"Omazing Z590", 199.99f},
        {"Omazing B660", 149.99f},
        {"Omazing B460", 119.99f},
        {"Omazing B360", 109.99f},
        {"Omazing B260", 79.99f},

        // PSU
        {"Omazing 300w", 39.99f},
        {"Omazing 500w", 59.99f},
        {"Omazing 750w", 99.99f},
        {"Omazing 800w", 119.99f},
        {"Omazing 1000w", 209.99f},
        {"Omazing 1500w", 399.99f},

        // Storage
        {"500GB SSD", 34.99f},
        {"1TB SSD", 59.99f},
        {"2TB SSD", 109.99f},
        {"1TB HDD", 34.99f},
        {"2TB HDD", 49.99f},
        {"4TB HDD", 69.99f},
        {"8TB HDD", 119.99f},

        // Cooling
        {"Omazing 1x120mm", 19.99f},
        {"Omazing 2x120mm", 39.99f},
        {"Omazing 3x120mm", 69.99f},
        {"Omazing 6x120mm", 99.99f},

        // Case
        {"Omazing M-ATX", 69.99f},
        {"Omazing ATX", 99.99f},
        {"Omazing E-ATX", 149.99f},

        // Software

        // Accessories

    };

    public static readonly Dictionary<string, int> code = new Dictionary<string, int>()
    {
        {"THISGAMESUCKS", -100},
        {"OMAZING", 10},
        {"SORRY", 20},
        {"JOVANNMC", 100},
    };
}
