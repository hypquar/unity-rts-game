using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionUI : MonoBehaviour
{

    [SerializeField]
    RectTransform _boxVisual;

    Camera _cam;

    Rect _selectionBox;

    Vector2 _startPosition;
    Vector2 _endPosition;

    void Start()
    {
        _cam = Camera.main;
        _startPosition = Vector2.zero;
        _endPosition = Vector2.zero;
        DrawVisual();
    }

    void Update()
    {
        if (!IsMouseOverUI())
        { 
            // When Clicked
            if (Input.GetMouseButtonDown(0))
            {

                _startPosition = Input.mousePosition;

                // For selection the Units
                _selectionBox = new Rect();
            }

            // When Dragging
            if (Input.GetMouseButton(0))
            {
                _endPosition = Input.mousePosition;
                DrawVisual();
                DrawSelection();
            }

            // When Releasing
            if (Input.GetMouseButtonUp(0))
            {
                SelectUnits();

                _startPosition = Vector2.zero;
                _endPosition = Vector2.zero;
                DrawVisual();
            }
        }
    }



    /// <summary>
    /// Checks if cursor is over UI with Graphic Raycaster component.
    /// </summary>
    /// <returns>Bool. True if it's over UI with Graphic Raycaster component, false if it's not.</returns>

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
        Vector2 boxStart = _startPosition;
        Vector2 boxEnd = _endPosition;

        // Calculate the center of the selection box.
        Vector2 boxCenter = (boxStart + boxEnd) / 2;

        // Set the position of the visual selection box based on its center.
        _boxVisual.position = boxCenter;

        // Calculate the size of the selection box in both width and height.
        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        // Set the size of the visual selection box based on its calculated size.
        _boxVisual.sizeDelta = boxSize;
    }



    /// <summary>
    /// Compares startPosition and Input.mousePosition coordinates on the x and y axises and sets the greater values as xMax or yMax and the lesser one as xMin or yMin in selectionBox.
    /// </summary>

    void DrawSelection()
    {
        if (Input.mousePosition.x < _startPosition.x)
        {
            _selectionBox.xMin = Input.mousePosition.x;
            _selectionBox.xMax = _startPosition.x;
        }
        else
        {
            _selectionBox.xMin = _startPosition.x;
            _selectionBox.xMax = Input.mousePosition.x;
        }


        if (Input.mousePosition.y < _startPosition.y)
        {
            _selectionBox.yMin = Input.mousePosition.y;
            _selectionBox.yMax = _startPosition.y;
        }
        else
        {
            _selectionBox.yMin = _startPosition.y;
            _selectionBox.yMax = Input.mousePosition.y;
        }
    }



    /// <summary>
    /// Checks if objects in allSelectableObjects are in selectionBox, and if they are adds them to selectedObjects.
    /// </summary>
    
    void SelectUnits()
    {
        foreach (var unit in SelectionManager.Instance.allSelectableObjects)
        {
            if (_selectionBox.Contains(_cam.WorldToScreenPoint(unit.transform.position)))
            {
                SelectionManager.Instance.DragSelect(unit);
            }
        }
    } 
}
