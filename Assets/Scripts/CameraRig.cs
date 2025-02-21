using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public static CameraRig instance;

    Vector3 newPosition;

    [SerializeField]
    float normalSpeed = 0.05f;

    [SerializeField]
    float movementSensitivity = 2f;

    float movementSpeed;

    [SerializeField]
    float edgeSize = 50f;

    [SerializeField]
    float maxFOV = 100.0f;

    [SerializeField]
    float scrollSensivity = 5.0f;
    
    private Camera cam;

    private void Start()
    {
        instance = this;

        cam = Camera.main;

        newPosition = transform.position;

        movementSpeed = normalSpeed;
    }

    void Update()
    {
        HandleCameraMovement();
        HandleCameraZoom();
    }



    /// <summary>
    /// Defines camera movement from keyboard and mouse input.
    /// Uses arrow keys and mousePosition as input.
    /// </summary>
    
    void HandleCameraMovement()
    {
        // movement with keys

        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        
        // movement with mouse

        if (Input.mousePosition.x > Screen.width - edgeSize)
        {
            newPosition += (transform.right * movementSpeed);
            Debug.Log("Mouse on right edge");
        }
        
        else if (Input.mousePosition.x < edgeSize)
        {
            newPosition += (transform.right * -movementSpeed);
            Debug.Log("Mouse on left edge");
        }
        
        else if (Input.mousePosition.y > Screen.height - edgeSize)
        {
            newPosition += (transform.forward * movementSpeed);
        }
        
        else if (Input.mousePosition.y < edgeSize)
        {
            newPosition += (transform.forward * -movementSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementSensitivity);
    }



    /// <summary>
    /// Handles camera zoom by adjusting fieldOfView variable.
    /// Uses scroll wheel axis as input
    /// </summary>
    
    void HandleCameraZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && cam.fieldOfView < maxFOV)
        {
            cam.fieldOfView += scrollSensivity;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && cam.fieldOfView > 5)
        {
            cam.fieldOfView -= scrollSensivity;
        }
    }
}
