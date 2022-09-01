using Strawhenge.Builder.Unity;
using UnityEngine;

public class MenuExample : MonoBehaviour
{
    [SerializeField] string[] _categories;
    [SerializeField] string[] _items;
    [SerializeField] bool _enableBack;

    MenuView _menuView;
    bool _isShowing;

    void Awake()
    {
        _menuView = new MenuView();
    }

    void Start()
    {
        _menuView.Setup(
            FindObjectOfType<MenuScript>(includeInactive: true));
    }

    void Update()
    {
        if (!Input.GetKeyUp(KeyCode.Escape))
            return;

        if (_isShowing)
            _menuView.Hide();
        else
            _menuView.Show(_categories, _items, _enableBack);

        _isShowing = !_isShowing;
    }
}

