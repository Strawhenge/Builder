using Strawhenge.Builder.Unity.Monobehaviours;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Editor
{
    [CustomEditor(typeof(BuilderScript))]
    public class BuilderScriptEditor : UnityEditor.Editor
    {
        BuilderScript _target;

        void OnEnable()
        {
            _target ??= target as BuilderScript;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Builder Manager", EditorStyles.boldLabel);

            EditorGUI.BeginDisabledGroup(!Application.isPlaying);
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button(nameof(BuilderManager.On)))
                _target.BuilderManager.On();

            if (GUILayout.Button(nameof(BuilderManager.Off)))
                _target.BuilderManager.Off();

            EditorGUILayout.EndHorizontal();
            EditorGUI.EndDisabledGroup();
        }
    }
}