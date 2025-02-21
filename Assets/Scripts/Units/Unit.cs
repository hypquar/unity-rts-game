using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public UnitData unitData;

    int _currentHealth;
    NavMeshAgent _agent;

    void Start()
    {
        SelectionManager.Instance.allSelectableObjects.Add(gameObject);

        if (unitData == null)
        {
            Debug.LogError("UnitData не назначен на " + gameObject.name);
            return;
        }

        _agent = GetComponent<NavMeshAgent>();
        _currentHealth = unitData.health;

        _agent.acceleration = unitData.speed;
    }


    void OnDestroy()
    {
        SelectionManager.Instance.allSelectableObjects.Remove(gameObject);
    }
}
