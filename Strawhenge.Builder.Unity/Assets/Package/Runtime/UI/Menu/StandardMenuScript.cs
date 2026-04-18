using Strawhenge.Builder.Menu;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Strawhenge.Builder.Unity.UI.Menu
{
    public class StandardMenuScript : BaseMenuScript, IMenuView
    {
        [SerializeField] Canvas _canvas;
        [SerializeField] Button _exitButton;
        [SerializeField] Button _backButton;
        [SerializeField] Transform _buttonParent;
        [SerializeField] Button _categoryButtonPrefab;
        [SerializeField] Button _itemButtonPrefab;

        readonly List<GameObject> _currentButtons = new List<GameObject>();

        public override IMenuView MenuView => this;
        
        void Awake()
        {
            _backButton.gameObject.SetActive(false);
            _backButton.onClick.AddListener(() => SelectBack?.Invoke());

            _exitButton.onClick.AddListener(() => SelectExit?.Invoke());

            _canvas.enabled = false;
        }

        public event Action<string> SelectCategory;
        public event Action<string> SelectItem;
        public event Action SelectBack;
        public event Action SelectExit;

        public void Show(IReadOnlyList<string> categories, IReadOnlyList<string> items, bool enableBack)
        {
            RemoveAll();

            foreach (var category in categories)
                AddCategory(category);

            foreach (var item in items)
                AddItem(item);

            _canvas.enabled = true;
            _backButton.gameObject.SetActive(enableBack);
        }

        public void Hide()
        {
            _canvas.enabled = false;
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