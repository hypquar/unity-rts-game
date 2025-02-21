
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingData buildingData;

    int _woodRequired;
    int _rocksRequired;

    void Start()
    {
        SelectionManager.Instance.allSelectableObjects.Add(gameObject);


    }

    void Update()
    {
        if (SelectionManager.Instance.selectedObjects.Contains(gameObject))
        {
            
        }
    }

    void OnDestroy()
    {
        SelectionManager.Instance.allSelectableObjects.Remove(gameObject);
    }


    
}

