using UnityEngine;

public class PerlinResourceGenerator : MonoBehaviour
{
    public int width = 1000;
    public int height = 1000;
    public float scale = 10f;

    public GameObject treePrefab;
    public GameObject stonePrefab;

    void Start()
    {
        GenerateResources();
    }

    void GenerateResources()
    {
        for (int x = 0; x < width; x+=2)
        {
            for (int y = 0; y < height; y+=2)
            {
                float noiseValue = Mathf.PerlinNoise(x / scale, y / scale);

                Vector3 spawnPos = new Vector3(x, 0, y); // Подстрой высоту по рельефу

                if (noiseValue > 0.9f)
                {
                    Instantiate(treePrefab, spawnPos, Quaternion.identity);
                }
                else if (noiseValue < 0.1f)
                {
                    Instantiate(stonePrefab, spawnPos, Quaternion.identity);
                }
            }
        }
    }
}
