using UnityEngine;

[CreateAssetMenu(fileName = "NewUnit", menuName = "RTS/NewUnit")]
[System.Serializable]
public class UnitData : ScriptableObject
{
    public string unitName;

    public int health;
    public int damage;
    public int level;
    public int requiredWood;
    public int requiredStone;

    public float speed;
    public float attackRange;

    public GameObject preset;
}
