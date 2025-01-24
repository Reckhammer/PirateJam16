using UnityEngine;

public class FPCamera : MonoBehaviour
{
    // Todo: do some settings to pull sensitivity from\
    // Todo: add invert y feature
    // Todo: clean up this shit
    public Camera m_Camera;
    private Transform cameraTransform;
    public float xSensitivity = 1.5f;
    public float ySensitivity = 30f;
    public float smoothing = 1.5f;
    public bool canMove = true;

    private float xMousePos;
    private float yMousePos;
    private float verticalRotation = 0f;

    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
        cameraTransform = m_Camera.transform;

        if (cameraTransform == null)
            Debug.LogError($"Couldn't find Camera under {this.name}", this);
    }

    private void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GetComponent<Health>().Death += DisableMovement;
    }

    void Update()
    {
        //GetInput();
        //ModifyInput();
        //MovePlayerCamera();

        if (canMove)
        {
            xMousePos = Input.GetAxis("Mouse X") * xSensitivity;
            yMousePos = Input.GetAxis("Mouse Y") * ySensitivity;

            // Vertical Modification
            verticalRotation -= yMousePos * Time.deltaTime;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

            // Move
            transform.Rotate(Vector3.up * xMousePos); // Horizontal
            cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f); // Vertical
        }
    }

    private void GetInput()
    {
        xMousePos = Input.GetAxis("Mouse X");
        yMousePos = Input.GetAxis("Mouse Y");
        Debug.Log($"Get Input: yMousePos = {yMousePos}");
    }

    private void ModifyInput()
    {
        // Horizontal
        xMousePos *= xSensitivity;
        //smoothedXMousePos = Mathf.Lerp(smoothedXMousePos, xMousePos, 1f / smoothing);

        // Vertical
        float clampVal = Mathf.Clamp(yMousePos * xSensitivity * -1, -90, 90);
        Debug.Log($"ModifyInput: clamp = {Mathf.Clamp(clampVal, -90, 90)}");
        yMousePos = Mathf.Clamp(xSensitivity * yMousePos * -1, -90, 90);
        //smoothedYMousePos = Mathf.Clamp(Mathf.Lerp(smoothedYMousePos, yMousePos, 1f / smoothing), -90f, 90f);
    }

    private void MovePlayerCamera()
    {
        if (canMove)
        {
            // Horizontal
            //currentLookingXPos += smoothedXMousePos;
            transform.Rotate(Vector3.up * xMousePos);

            // Vertical
            //currentLookingYPos += smoothedYMousePos;
            cameraTransform.localRotation = Quaternion.Euler(yMousePos, 0f, 0f);
        }
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }
}
