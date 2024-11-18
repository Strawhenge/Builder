using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.Monobehaviours;
using System;
using UnityEngine;

public class BuildItemScriptSelector : MonoBehaviour, IBuildItemScriptSelector
{
    [SerializeField] Camera _camera;

    public event Action<BuildItemScript> Select;

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }

    void Awake()
    {
        enabled = false;
    }

    void Update()
    {
        HandleExistingItemClick();
    }

    void HandleExistingItemClick()
    {
        if (!Input.GetMouseButtonDown(0) || !Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit))
            return;

        var buildItemScript = hit.transform.root.GetComponentInChildren<BuildItemScript>();

        if (buildItemScript != null)
            Select?.Invoke(buildItemScript);
    }
}
