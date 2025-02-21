using UnityEngine;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "RTS/NewBuilding")]
[System.Serializable]
public class BuildingData: ScriptableObject
{
    public string buildingName;

    public int health;
    public int level;
    public int damage;
    public int woodRequired;
    public int rocksRequired;

    public float attackRange;

    public UnitData[] buildableUnitsData;

    public GameObject preset;
}
