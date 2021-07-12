using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : ScriptableObject
{
    public ISelectable CurrentValue { get; private set; }
    public Action<ISelectable> OnSelected;
    public Action<SelectableValue> OnDeselected;
    public void SetValue(ISelectable value) {
        CurrentValue = value;
        OnSelected?.Invoke(value);
    }

    public void Deselect(SelectableValue value)
    {
        if (value != null)
        {
            OnDeselected?.Invoke(value);
        }
    }
}