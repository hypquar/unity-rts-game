using UnityEngine;

public class BuildingPreview : MonoBehaviour
{
    public Vector3 boxSize = new Vector3(5f, 5f, 5f); // Размеры здания
    public LayerMask forbiddenLayers; // Слои, которые нельзя пересекать
    public GameObject buildingPrefab;


    private bool _isObstructed             ;

    void Update()
    {
        // Проверяем пересечение
        Collider[] colliders = Physics.OverlapBox(transform.position, boxSize / 2, Quaternion.identity, forbiddenLayers);

        if (colliders.Length > 0)
        {
            Debug.Log("Пересечение! Нельзя строить.");
        }
        else
        {
            Debug.Log("Можно строить.");
        }
    }

    // Визуализация границ в редакторе
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}

