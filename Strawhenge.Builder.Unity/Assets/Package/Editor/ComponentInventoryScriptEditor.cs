using Strawhenge.Builder.Unity.Components;
using Strawhenge.Common;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Editor
{
    [CustomEditor(typeof(ComponentInventoryScript))]
    public class ComponentInventoryScriptEditor : UnityEditor.Editor
    {
        ComponentInventoryScript _target;
        ComponentScriptableObject _component;
        int _quantity = 1;
        bool _infiniteComponents;
        bool _showContents;

        void OnEnable()
        {
            _target ??= target as ComponentInventoryScript;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Separator();

            EditorGUILayout.LabelField("Inventory", EditorStyles.boldLabel);
            EditorGUI.BeginDisabledGroup(!Application.isPlaying);

            _component = EditorGUILayout.ObjectField(
                "Component",
                _component,
                typeof(ComponentScriptableObject),
                false) as ComponentScriptableObject;

            _quantity = EditorGUILayout.IntField("Quantity", _quantity);

            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginDisabledGroup(_component == null);

            if (GUILayout.Button(nameof(ComponentInventory.AddComponent)))
                _target.Inventory.AddComponent(new Component(_component!.Identifier), _quantity);

            if (GUILayout.Button(nameof(ComponentInventory.RemoveComponent)))
                _target.Inventory.RemoveComponent(new Component(_component!.Identifier), _quantity);

            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button(nameof(ComponentInventory.RemoveAllComponents)))
                _target.Inventory.RemoveAllComponents();

            _infiniteComponents = EditorGUILayout.Toggle("Infinite Components", _infiniteComponents);
            if (_infiniteComponents != _target.Inventory.InfiniteComponents)
                _target.Inventory.InfiniteComponents = _infiniteComponents;

            _showContents = EditorGUILayout.Foldout(_showContents, "Contents");
            if (_showContents)
                EditorGUILayout.HelpBox(CreateContentsString(), MessageType.Info);

            EditorGUI.EndDisabledGroup();
        }

        string CreateContentsString()
        {
            var stringBuilder = new StringBuilder();

            _target.Inventory.GetComponents().ForEach(componentQuantity =>
                stringBuilder.AppendLine($"{componentQuantity.Component.Identifier}: {componentQuantity.Quantity}")
            );

            return stringBuilder.ToString();
        }
    }
}