using Strawhenge.Builder.Unity;
using System;
using UnityEngine;

public class BuilderManagerUI : MonoBehaviour, IBuilderManagerUI
{
    public event Action ExitBuilder;
    public event Action OpenMenu;

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = true;
    }

    void Awake()
    {
        enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            OpenMenu?.Invoke();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            ExitBuilder?.Invoke();
    }
}
