using UnityEngine;

public class BuildingPreview : MonoBehaviour
{
    public Vector3 boxSize = new Vector3(5f, 5f, 5f); // ������� ������
    public LayerMask forbiddenLayers; // ����, ������� ������ ����������
    public GameObject buildingPrefab;


    private bool _isObstructed             ;

    void Update()
    {
        // ��������� �����������
        Collider[] colliders = Physics.OverlapBox(transform.position, boxSize / 2, Quaternion.identity, forbiddenLayers);

        if (colliders.Length > 0)
        {
            Debug.Log("�����������! ������ �������.");
        }
        else
        {
            Debug.Log("����� �������.");
        }
    }

    // ������������ ������ � ���������
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}

