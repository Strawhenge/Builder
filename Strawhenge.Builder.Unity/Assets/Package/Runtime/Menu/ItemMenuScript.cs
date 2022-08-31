using System.Collections.Generic;
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

        readonly List<GameObject> _currentButtons = new List<GameObject>();

        void Awake()
        {
            _backButton.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

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

        void AddItem(string itemName) => Add(itemName, _itemButtonPrefab);

        void AddCategory(string categoryName) => Add(categoryName, _categoryButtonPrefab);

        void Add(string buttonText, Button buttonPrefab)
        {
            var button = Instantiate(buttonPrefab, parent: _buttonParent);
            button.GetComponentInChildren<Text>().text = buttonText;

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
