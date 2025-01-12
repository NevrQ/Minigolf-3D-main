using UnityEngine;

public class MinigolfCamera : MonoBehaviour
{
    public Transform ball; 
    public Vector3 offset = new Vector3(0, 5, -10); 
    public float rotationSpeed = 100f; 
    public float zoomSpeed = 10f; 
    public float minZoom = 5f; 
    public float maxZoom = 20f; 

    private float currentZoom = 10f;
    private float currentYaw = 0f; 

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= scroll * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        if (Input.GetMouseButton(1)) 
        {
            float horizontal = Input.GetAxis("Mouse X");
            currentYaw += horizontal * rotationSpeed * Time.deltaTime;
        }
    }

    void LateUpdate()
    {
        if (ball == null) return;

        Vector3 desiredPosition = ball.position - offset.normalized * currentZoom;
        transform.position = desiredPosition;

        transform.LookAt(ball.position);

        transform.RotateAround(ball.position, Vector3.up, currentYaw);
    }
}