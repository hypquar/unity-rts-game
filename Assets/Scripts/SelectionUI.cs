using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionUI : MonoBehaviour
{
    Camera myCam;

    [SerializeField]
    RectTransform boxVisual;

    Rect selectionBox;

    Vector2 startPosition;
    Vector2 endPosition;

    private void Start()
    {
        myCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
    }

    private void Update()
    {
        if (!IsMouseOverUI())
        { 
            // When Clicked
            if (Input.GetMouseButtonDown(0))
            {

                startPosition = Input.mousePosition;

                // For selection the Units
                selectionBox = new Rect();
            }

            // When Dragging
            if (Input.GetMouseButton(0))
            {
                endPosition = Input.mousePosition;
                DrawVisual();
                DrawSelection();
            }

            // When Releasing
            if (Input.GetMouseButtonUp(0))
            {
                SelectUnits();

                startPosition = Vector2.zero;
                endPosition = Vector2.zero;
                DrawVisual();
            }
        }
    }



    /// <summary>
    /// Checks if cursor is over UI with Graphic Raycaster component.
    /// </summary>
    /// <returns></returns>
    public static bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }



    /// <summary>
    /// Calculates the size and position of the selection box and sets its size in position based on calculated ones.
    /// </summary>

    void DrawVisual()
    {
        // Calculate the starting and ending positions of the selection box.
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        // Calculate the center of the selection box.
        Vector2 boxCenter = (boxStart + boxEnd) / 2;

        // Set the position of the visual selection box based on its center.
        boxVisual.position = boxCenter;

        // Calculate the size of the selection box in both width and height.
        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        // Set the size of the visual selection box based on its calculated size.
        boxVisual.sizeDelta = boxSize;
    }



    /// <summary>
    /// Compares startPosition and Input.mousePosition coordinates on the x and y axises and sets the greater values as xMax or yMax and the lesser one as xMin or yMin in selectionBox.
    /// </summary>

    void DrawSelection()
    {
        if (Input.mousePosition.x < startPosition.x)
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }


        if (Input.mousePosition.y < startPosition.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }



    /// <summary>
    /// Checks if objects in allSelectableObjects are in selectionBox, and if they are adds them to selectedObjects.
    /// </summary>
    
    void SelectUnits()
    {
        foreach (var unit in SelectionManager.Instance.allSelectableObjects)
        {
            if (selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.position)))
            {
                SelectionManager.Instance.DragSelect(unit);
            }
        }
    } 
}
