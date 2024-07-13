using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    public Transform target; // The target (player) the camera will follow
    public SpriteRenderer background; // The background image
    public float moveSpeed = 10f; // Speed of camera movement

    private Vector3 minBounds;
    private Vector3 maxBounds;
    private float cameraHalfWidth;
    private float cameraHalfHeight;

    void Start()
    {
        // Calculate the bounds of the background image
        minBounds = background.bounds.min;
        maxBounds = background.bounds.max;

        // Get the camera dimensions in world units
        Camera cam = Camera.main;
        cameraHalfHeight = cam.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * cam.aspect;
    }

    void Update()
    {
        // Get input for camera movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the desired position
        Vector3 desiredPosition = transform.position + new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;

        // Clamp the camera position to stay within the bounds of the background image
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + cameraHalfWidth, maxBounds.x - cameraHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + cameraHalfHeight, maxBounds.y - cameraHalfHeight);

        // Set the camera's position
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void OnDrawGizmos()
    {
        if (background != null)
        {
            // Draw the bounds of the background image in the scene view for visualization
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector3(minBounds.x, minBounds.y, 0), new Vector3(minBounds.x, maxBounds.y, 0));
            Gizmos.DrawLine(new Vector3(minBounds.x, maxBounds.y, 0), new Vector3(maxBounds.x, maxBounds.y, 0));
            Gizmos.DrawLine(new Vector3(maxBounds.x, maxBounds.y, 0), new Vector3(maxBounds.x, minBounds.y, 0));
            Gizmos.DrawLine(new Vector3(maxBounds.x, minBounds.y, 0), new Vector3(minBounds.x, minBounds.y, 0));
        }
    }
}
