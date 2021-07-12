using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private Transform _unitsParent;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;

    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private Material _selectedMaterial;

    private float _health = 1000;

    private void Start()
    {
        _selectableValue.OnSelected += onSelected;
    }

    public void onSelected(ISelectable selected)
    {
        Debug.Log("onSelected");
        if (selected == null)
            return;
        _selectableValue.OnDeselected += onDeselected;
        AddMaterial(_selectedMaterial);
    }
    public void onDeselected(SelectableValue selected)
    {
        Debug.Log("onDeselected");
        RemoveMaterial(_selectedMaterial);
        selected.OnDeselected -= onDeselected;
    }

    private void AddMaterial(Material material)
    {
        
        Material[] materials = gameObject.GetComponent<Renderer>().materials;
        List<Material> newMaterials = new List<Material>();
        for (int i = 0; i < materials.Length; i++)
        {
            newMaterials.Add(materials[i]);
        }
        newMaterials.Add(material);
        gameObject.GetComponent<Renderer>().materials = newMaterials.ToArray();
    }

    private void RemoveMaterial(Material material)
    {
        Material[] materials = gameObject.GetComponent<Renderer>().materials;
        List<Material> newMaterials = new List<Material>();
        for (int i = 0; i < materials.Length; i++)
        {
            
            if (!materials[i].name.Contains(material.name))
            {
                newMaterials.Add(materials[i]);
            }
        }
        gameObject.GetComponent<Renderer>().materials = newMaterials.ToArray();
    }

    public void ProduceUnit()
    {
        Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)) + transform.position, Quaternion.identity, _unitsParent);
    }
}
