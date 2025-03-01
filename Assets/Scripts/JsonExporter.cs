using System.IO;
using UnityEngine;

public class JsonExporter : MonoBehaviour
{
    [SerializeField] private UnitData[] _unitDataList;

    private DataManager _dataManager;

    private string unitDirectoryPath;
    void Start()
    {
        _dataManager = DataManager.Instance;

        unitDirectoryPath = _dataManager.unitConfigPath;
        
        foreach (UnitData unitData in _unitDataList)
        {
            string json = JsonUtility.ToJson(unitData);
            string filePath = Path.Combine(unitDirectoryPath, $"{unitData.name}.json");

            File.WriteAllText(filePath, json);

            Debug.Log(filePath);
        }
    }
}
