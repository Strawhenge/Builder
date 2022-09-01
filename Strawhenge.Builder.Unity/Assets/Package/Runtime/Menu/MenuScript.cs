using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity
{
    public class MenuScript : MonoBehaviour
    {
        [SerializeField] Button _exitButton;
        [SerializeField] Button _backButton;
        [SerializeField] Transform _buttonParent;
        [SerializeField] Button _categoryButtonPrefab;
        [SerializeField] Button _itemButtonPrefab;

        readonly List<GameObject> _currentButtons = new List<GameObject>();

        void Awake()
        {
            _backButton.gameObject.SetActive(false);
            _backButton.onClick.AddListener(() => SelectBack?.Invoke());
            gameObject.SetActive(false);
        }

        public Action<string> SelectCategory { private get; set; }

        public Action<string> SelectItem { private get; set; }

        public Action SelectBack { private get; set; }

        public void Show(IEnumerable<string> categories, IEnumerable<string> items, bool enableBack)
        {
            RemoveAll();

            foreach (var category in categories)
                AddCategory(category);

            foreach (var item in items)
                AddItem(item);

            gameObject.SetActive(true);
            _backButton.gameObject.SetActive(enableBack);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        void AddItem(string itemName) =>
            Add(itemName, _itemButtonPrefab, () => SelectItem?.Invoke(itemName));

        void AddCategory(string categoryName) =>
            Add(categoryName, _categoryButtonPrefab, () => SelectCategory?.Invoke(categoryName));

        void Add(string buttonText, Button buttonPrefab, UnityAction onClick)
        {
            var button = Instantiate(buttonPrefab, parent: _buttonParent);
            button.GetComponentInChildren<Text>().text = buttonText;
            button.onClick.AddListener(onClick);
            _currentButtons.Add(button.gameObject);
        }

        void RemoveAll()
        {
            foreach (var button in _currentButtons.ToArray())
            {
                _currentButtons.Remove(button);
                Destroy(button);
            }
        }
    }
}
