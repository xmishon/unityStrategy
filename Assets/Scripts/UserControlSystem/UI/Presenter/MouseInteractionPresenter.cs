using System.Linq;
using UnityEngine;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;

    private ISelectable _selectable;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
        if (hits.Length == 0)
        {
            _selectedObject.Deselect(_selectedObject);
            _selectedObject.SetValue(null);
            return;
        }
        _selectable = hits
                .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                .Where(c => c != null)
                .FirstOrDefault();
        if (_selectable == null)
        {
            _selectedObject.Deselect(_selectedObject);
        }
        _selectedObject.SetValue(_selectable);
        
    }

}
