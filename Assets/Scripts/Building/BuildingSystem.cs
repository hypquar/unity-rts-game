using UnityEngine;
using UnityEngine.AI;


public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Instance { get; set; }

    public Building[] buildingPrefabs;
    public LayerMask ground;
    public LayerMask clickable;

    Camera _cam;
    bool _isInBuildingMode;
    int _buildingIndex;
    Building _previewInstance;
    Building _buildingPrefab;

    void Awake()
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

    void Start()
    {
        _cam = Camera.main;
        _isInBuildingMode = false;
    }

    void Update()
    {
        //  ���� ������ ������ ������ �� �� �������� ������� �������� ������, �������������� ������� ���� ������ ���������, ������� ���� ����� 
        //  ���� ������ ���, ����� �������� � ���� ������� - ���������� ��������� ������
        //  �� ������� ��� ������ �������������


        if (_isInBuildingMode)
        {
            if (!Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit, Mathf.Infinity, ground);

                Vector3 previewPosition = hit.point + (Vector3.up * (Instance.buildingPrefabs[_buildingIndex].GetComponent<Renderer>().bounds.size.y) * 0.5f); 

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    if (IsFitting(_buildingIndex, hit.point))
                    {
                        HandleBuildingPreview(_buildingIndex, previewPosition, true);
                        if (Input.GetMouseButtonDown(0))
                        {
                            Instantiate(_buildingPrefab, previewPosition, Quaternion.identity);
                            Destroy(gameObject.transform.GetChild(0).gameObject);

                            CreatePreview();
                        }

                    }
                    else
                    {
                        HandleBuildingPreview(_buildingIndex, previewPosition, false);
                    }
                }
                else
                {
                    HandleBuildingPreview(_buildingIndex, previewPosition, false);
                }
            }
            else
            {
                _isInBuildingMode = false;
                Destroy(gameObject.transform.GetChild(0).gameObject);
            }
        }
    }



    void CreatePreview()
    {
        if (_buildingPrefab != null)
        {
            _previewInstance = Instantiate(_buildingPrefab, transform);
            _previewInstance.transform.localScale = _buildingPrefab.transform.localScale;

            foreach (Collider col in _previewInstance.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }

            foreach (MonoBehaviour script in _previewInstance.GetComponentsInChildren<MonoBehaviour>())
            {
                script.enabled = false;
            }

            foreach (NavMeshObstacle obstacle in _previewInstance.GetComponentsInChildren<NavMeshObstacle>())
            {
                obstacle.enabled = false;
            }
        }
    }

    void HandleBuildingPreview(int buildingIndex, Vector3 previewPosition, bool isBuildable)
    {
        _previewInstance.transform.position = previewPosition;
        _previewInstance.transform.GetChild(0).gameObject.SetActive(true);

        if (isBuildable)
        {
            _previewInstance.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            _previewInstance.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    bool IsFitting(int buildingIndex, Vector3 point)
    {
        Renderer renderer = Instance.buildingPrefabs[buildingIndex].GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size;

        Collider[] colliders = Physics.OverlapBox(point, size * 1.5f, Quaternion.identity, clickable);

        if (colliders.Length > 0)
        {
            Debug.Log("�����������! ������ �������.");
            return false;
        }
        else
        {
            Debug.Log("����� �������.");
            return true;
        }
    }

    bool IsAffordable(int buildingIndex)
    {
        Building building = Instance.buildingPrefabs[buildingIndex];
        if (building.buildingData.woodRequired <= ResourcesManager.Instance.currentWood && building.buildingData.rocksRequired <= ResourcesManager.Instance.currentRocks)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ToggleBuildingMode(int buildingIndex)
    {
        if (IsAffordable(buildingIndex))
        {
            _isInBuildingMode = !_isInBuildingMode;
            _buildingIndex = buildingIndex;
            _buildingPrefab = Instance.buildingPrefabs[buildingIndex];

            CreatePreview();
        }
        else
        {
            SoundManager.Instance.PlaySoundOnce(SoundManager.Instance._uiSFX, SoundManager.Instance.sfxClips[1]);
        }
    }
}
