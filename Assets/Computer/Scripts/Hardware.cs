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
    public static readonly Dictionary<string, float[]> gpu = new Dictionary<string, float[]>()
    {
        {"RPX 4090", new float[] { 6.0f, 450.0f } },
        {"RPX 4080", new float[] { 5.5f, 320.0f } },
        {"RPX 4070 Ti", new float[] { 5.2f, 285.0f } },
        {"RPX 4070", new float[] { 4.8f, 220.0f } },
        {"RPX 3090 Ti", new float[] { 4.7f, 450.0f } },
        {"RPX 3090", new float[] { 4.5f, 350.0f } },
        {"RPX 3080 Ti", new float[] { 4.2f, 350.0f } },
        {"RPX 3080", new float[] { 4.0f, 400.0f } },
        {"RPX 3070 Ti", new float[] { 3.8f, 290.0f } },
        {"RPX 3070", new float[] { 3.5f, 220.0f } },
        {"RPX 3060 Ti", new float[] { 3.2f, 200.0f } },
        {"RPX 3060", new float[] { 3.0f, 170.0f } },
        {"RPX 2080 Ti", new float[] { 3.4f, 250.0f } },
        {"RPX 2080", new float[] { 3.2f, 215.0f } },
        {"RPX 2070 Super", new float[] { 3.0f, 215.0f } },
        {"RPX 2070", new float[] { 2.88f, 175.0f } },
        {"RPX 2060 Super", new float[] { 2.65f, 175.0f } },
        {"RPX 2060", new float[] { 2.43f, 160.0f } },
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
}
