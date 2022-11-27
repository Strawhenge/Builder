﻿using Strawhenge.Builder.Unity.ScriptableObjects;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class BuilderScript : MonoBehaviour
    {
        [SerializeField] BlueprintScriptableObject[] _blueprints;

        public BuilderManager Manager { private get; set; }

        public BlueprintRepository BlueprintRepository { private get; set; }

        void Start()
        {
            BlueprintRepository.Add(_blueprints);

            print(Manager);
        }
    }
}
