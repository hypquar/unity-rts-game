using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{


    
    private bool _isAccessable;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void PlaceBuilding(int index, Transform buildingPosition)
    {
        Building building = BuildingSystem.Instance.buildingPrefabs[index];
        Instantiate(building, buildingPosition);
    }
}
