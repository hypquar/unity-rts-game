using System.IO;
using UnityEngine;

public class JsonExporter : MonoBehaviour
{
    public UnitData[] unitDataList;
    public BuildingData[] buildingDataList;
    void Start()
    {

        string unitDirectoryPath = Path.Combine(Application.dataPath, "Units");
        Directory.CreateDirectory(unitDirectoryPath);

        string buildingDirectoryPath = Path.Combine(Application.dataPath, "Buildings");
        Directory.CreateDirectory(buildingDirectoryPath);

        foreach (UnitData unitData in unitDataList)
        {
            string json = JsonUtility.ToJson(unitData);
            string filePath = Path.Combine(unitDirectoryPath, $"{unitData.name}.json");

            File.WriteAllText(filePath, json);

            Debug.Log(filePath);
        }

        foreach (BuildingData buildingData in buildingDataList)
        {
            string json = JsonUtility.ToJson(buildingDataList);
            string filePath = Path.Combine(buildingDirectoryPath, $"{buildingData.name}.json");

            File.WriteAllText(filePath, json);

            Debug.Log(filePath);
        }
    }

    
}
