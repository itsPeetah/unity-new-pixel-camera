using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ScreenResizeNotifier : UIBehaviour
{
    public event UnityAction screenResized;

    protected override void OnRectTransformDimensionsChange()
    {
        screenResized?.Invoke();
    }
}
