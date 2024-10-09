using UnityEngine;

public class bulan : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the camera's transform
    public Vector3 offset; // Offset value to position the object relative to the camera
    private Vector3 originalPosition; // Store the original position of the object

    void Start()
    {
        // Store the original position
        originalPosition = transform.position;

        // If the cameraTransform is not set, find the main camera
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void LateUpdate()
    {
        // Set the position of the object to be the same as the camera's position plus the offset
        if (cameraTransform != null)
        {
            transform.position = cameraTransform.position + offset;

            // Optionally, you can also make the object rotate to face the same direction as the camera
            transform.rotation = cameraTransform.rotation;
        }
        else
        {
            // Reset to the original position if cameraTransform is null
            transform.position = originalPosition;
        }
    }
}
