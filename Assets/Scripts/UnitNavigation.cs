using UnityEngine;
using UnityEngine.AI;

public class UnitNavigation : MonoBehaviour
{

    // public GameObject unitTarget;
    public SelectionManager selectionManager;
    public LayerMask ground;

    private NavMeshAgent agent;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        selectionManager = GameObject.Find("SelectionManager").GetComponent<SelectionManager>();
        ground = LayerMask.GetMask("Ground");
        agent = GetComponent<NavMeshAgent>();
        
        
        agent.stoppingDistance = 1.0f; // ���������� �� ���������� 1 �����
    }

    void Update()
    {
        if (!SelectionUI.IsMouseOverUI())
        {
            if (Input.GetMouseButtonDown(1))
            {

                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {

                    if (selectionManager.selectedObjects.Contains(gameObject))
                    {

                        agent.SetDestination(hit.point);

                    }
                }
            }
        }
    }
}
