using UnityEngine;

public class Unit : MonoBehaviour
{
    
    void Start()
    {
        SelectionManager.Instance.allSelectableObjects.Add(gameObject);
    }
    void OnDestroy()
    {
        SelectionManager.Instance.allSelectableObjects.Remove(gameObject);
    }
}
