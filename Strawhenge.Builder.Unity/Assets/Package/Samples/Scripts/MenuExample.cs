using Strawhenge.Builder.Unity;
using UnityEngine;

public class MenuExample : MonoBehaviour
{
    [SerializeField] string[] _categories;
    [SerializeField] string[] _items;

    ItemMenuView _menuView;
    bool _isShowing;

    void Awake()
    {
        _menuView = new ItemMenuView();
    }

    void Start()
    {
        _menuView.Set(
            FindObjectOfType<ItemMenuScript>(includeInactive: true));
    }

    void Update()
    {
        if (!Input.GetKeyUp(KeyCode.Escape))
            return;

        if (_isShowing)
            _menuView.Hide();
        else
            _menuView.Show(_categories, _items);

        _isShowing = !_isShowing;
    }
}

