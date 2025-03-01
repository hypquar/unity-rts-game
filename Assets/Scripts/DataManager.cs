using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; set; }

    [SerializeField] private ScriptableObject[] _unitDataList;
    
    public string configPath;
    public string unitConfigPath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        configPath = Path.Combine(Application.dataPath, "Config");
        Directory.CreateDirectory(configPath);

        unitConfigPath = Path.Combine(configPath, "Units");
        Directory.CreateDirectory(unitConfigPath);

        LoadUnitConfigsFromJson();
    }

    private void LoadUnitConfigsFromJson()
    {
        foreach (UnitData unitData in _unitDataList)
        {
            string filePath = Path.Combine(unitConfigPath, unitData.name + ".json");

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                unitData.LoadFromJson(json);
                Debug.Log($"Загружен юнит: {unitData.unitName}");
            }
            else
            {
                Debug.LogError($"Файл {filePath} не найден!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
