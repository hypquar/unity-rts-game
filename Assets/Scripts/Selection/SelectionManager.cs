using System.Collections.Generic;
using UnityEngine;


public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; set; }

    public List<GameObject> allSelectableObjects = new List<GameObject>();
    public List<GameObject> selectedObjects = new List<GameObject>();
    public LayerMask clickable;
    public LayerMask ground;

    private Camera _cam;

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
    }

    void Update()
    {
        if (!SelectionUI.IsMouseOverUI())
        { 
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        AddByClicking(hit.collider.gameObject);
                    }
                    else
                    {
                        SelectByClicking(hit.collider.gameObject);
                    }
                }
                else
                {
                    if (!Input.GetKey(KeyCode.LeftControl))
                    {
                        DeselectAll();
                    }
                }
            }
        }
    }



    /// <summary>
    /// Selects object if it's not selected and deselects it if it's already selected.
    /// </summary>
    /// <param name="selectableObject">GameObject that is going to be added to selectedObjects list.</param>

    private void AddByClicking(GameObject selectableObject)
    {
        if (!selectedObjects.Contains(selectableObject))
        {
            selectedObjects.Add(selectableObject);
            ToggleSelectionIndicator(selectableObject, true);
        }

        else
        {
            selectedObjects.Remove(selectableObject);
            ToggleSelectionIndicator(selectableObject, false);
        }
    }



    /// <summary>
    /// Clears selectedObjects list from all objects.
    /// </summary>
    
    private void DeselectAll()
    {
        foreach (var selectableObject in selectedObjects)
        {
            ToggleSelectionIndicator(selectableObject, false);
        }
        selectedObjects.Clear();
    }



    /// <summary>
    /// Each click selects 1 object while deselecting the other objects.
    /// </summary>
    /// <param name="selectableObject">GameObject that you need to select.</param>

    private void SelectByClicking(GameObject selectableObject)
    {
        DeselectAll();
        selectedObjects.Add(selectableObject);
        ToggleSelectionIndicator(selectableObject, true);
    }



    /// <summary>
    /// Finds the first child of a GameObject (which should be a selection indicator) and toggles it's visibility depending on the boolean variable isEnable.
    /// </summary>
    /// <param name="selectableObject">GameObject that has the selection indicator as its first child.</param>
    /// <param name="isEnabled">Boolean value. If true enables indicator, if false disables it.</param>
    
    private void ToggleSelectionIndicator(GameObject selectableObject, bool isEnabled)
    {
        selectableObject.transform.GetChild(0).gameObject.SetActive(isEnabled);
    }



    /// <summary>
    /// Adds GameObject to selectedObjects list if it's not in the list already.
    /// </summary>
    /// <param name="selectableObject">GameObject that is being added.</param>
    
    internal void DragSelect(GameObject selectableObject)
    {
        if (!selectedObjects.Contains(selectableObject))
        {
            selectedObjects.Add(selectableObject);
            ToggleSelectionIndicator(selectableObject, true);
        }
    }
}
