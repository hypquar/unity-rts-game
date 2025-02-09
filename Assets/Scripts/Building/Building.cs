using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class Building : MonoBehaviour
{

    public int woodRequired;
    public int rocksRequired;


    public Canvas uiCanvas;
    public GameObject[] spawnableUnits;

    void Start()
    {
        SelectionManager.Instance.allSelectableObjects.Add(gameObject);

        woodRequired = 10;
        rocksRequired = 10;
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

