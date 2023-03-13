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
        {"GPX 4090", new float[] {2.0f, 450.0f}}
    };
}
