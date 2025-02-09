 using UnityEngine;
using UnityEngine.AI;

public class UnitNavigation : MonoBehaviour
{

    public LayerMask ground;

    private NavMeshAgent _agent;
    private Camera _cam;

    void Start()
    {
        ground = LayerMask.GetMask("Ground");

        _cam = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!SelectionUI.IsMouseOverUI())
        {
            if (Input.GetMouseButtonDown(1))
            {

                RaycastHit hit;
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {

                    if (SelectionManager.Instance.selectedObjects.Contains(gameObject))
                    {

                        _agent.SetDestination(hit.point);

                    }
                }
            }
        }
    }
}
