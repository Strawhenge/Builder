using System;
using UnityEngine;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity
{
    public class ItemMenuScript : MonoBehaviour
    {
        [SerializeField] Button _exitButton;
        [SerializeField] Button _backButton;
        [SerializeField] Transform _buttonParent;
        [SerializeField] Button _categoryButtonPrefab;
        [SerializeField] Button _itemButtonPrefab;

        void Awake()
        {
            _backButton.gameObject.SetActive(false);
        }

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

        void AddItem(string itemName) => AddButton(itemName, _itemButtonPrefab);

        void AddCategory(string categoryName) => AddButton(categoryName, _categoryButtonPrefab);

        void AddButton(string buttonText, Button buttonPrefab)
        {
            var button = Instantiate(buttonPrefab, parent: _buttonParent);
            button.GetComponentInChildren<Text>().text = buttonText;
        }
    }
}
