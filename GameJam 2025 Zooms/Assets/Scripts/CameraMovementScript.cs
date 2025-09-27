using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetPosition = playerTransform.position + offset;
        
        transform.position = new Vector3(targetPosition.x, 0, -10);

    }
}
