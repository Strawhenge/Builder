using System;
using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity
{
    public class ItemMenuScript : MonoBehaviour
    {
        [SerializeField] Transform _buttonParent;
        [SerializeField] Button _categoryButtonTemplate;
        [SerializeField] Button _itemButtonTemplate;

        void Start()
        {
            AddCategory("Walls");
            AddCategory("Floors");
            AddCategory("Stairs");
            AddCategory("Furniture");
            AddCategory("Utility");
            AddItem("Chair");
            AddItem("Table");
            AddItem("Toilet");
        }

        void AddItem(string itemName) => AddButton(itemName, _itemButtonTemplate);

        void AddCategory(string categoryName) => AddButton(categoryName, _categoryButtonTemplate);

        void AddButton(string buttonText, Button buttonPrefab)
        {
            var button = Instantiate(buttonPrefab, parent: _buttonParent);
            button.GetComponentInChildren<Text>().text = buttonText;
        }
    }
}
