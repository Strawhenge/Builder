using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public static class BuilderProgressSample
    {
        public static readonly BuilderProgressData Data = new BuilderProgressData
        {
            BuildItems = new BuildItemData[]
            {
                new BuildItemData()
                {
                    Name = "Floor",
                    Position = new Vector3(2.015505790710449F, 0.005000000819563866F, 1.7324241399765015F)
                },
                new BuildItemData()
                {
                    Name = "WallWithDoor",
                    Position = new Vector3(2.015505790710449F, 0.005000000819563866F, 1.2324241399765015F)
                },
                new BuildItemData()
                {
                    Name = "Wall",
                    Position = new Vector3(2.515505790710449F, 0.005000000819563866F, 1.7324241399765015F),
                    Rotation = new Quaternion(0, 0.7071067690849304F, 0, -0.70710688829422F)
                },
                new BuildItemData()
                {
                    Name = "Wall",
                    Position = new Vector3(2.015505790710449F, 0.004999995231628418F, 2.23242449760437F),
                    Rotation = new Quaternion(0, -1, 0, 1.6858736273661635e-7F)
                },
                new BuildItemData()
                {
                    Name = "Wall",
                    Position = new Vector3(1.5155055522918702F, 0.004999995231628418F, 1.7324247360229493F),
                    Rotation = new Quaternion(0, 0.7071069478988648F, 0, 0.7071065902709961F)
                },
                new BuildItemData()
                {
                    Name = "Floor",
                    Position = new Vector3(2.015505790710449F, 1.0049999952316285F, 1.7324241399765015F)
                }
            }
        };
    }
}