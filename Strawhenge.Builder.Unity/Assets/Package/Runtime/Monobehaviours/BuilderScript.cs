using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class BuilderScript : MonoBehaviour
    {
        public BuilderManager Manager { private get; set; }

        void Start()
        {
            print(Manager);
        }
    }
}
