using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.Progress;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Editor
{
    [CustomEditor(typeof(BuilderScript))]
    public class BuilderScriptEditor : UnityEditor.Editor
    {
        BuilderScript _target;
        bool _importToggle;
        BuilderProgressDataScriptableObject _progressData;

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

            _importToggle = EditorGUILayout.Foldout(_importToggle, "Import");

            if (_importToggle)
            {
                _progressData = (BuilderProgressDataScriptableObject)EditorGUILayout.ObjectField(
                    "Progress",
                    _progressData,
                    typeof(BuilderProgressDataScriptableObject),
                    allowSceneObjects: false
                );

                EditorGUI.BeginDisabledGroup(_progressData == null);

                if (GUILayout.Button(nameof(ProgressManager.Import)))
                    _target.BuilderManager.Progress.Import(_progressData);

                EditorGUI.EndDisabledGroup();
            }

            EditorGUI.EndDisabledGroup();
        }
    }
}