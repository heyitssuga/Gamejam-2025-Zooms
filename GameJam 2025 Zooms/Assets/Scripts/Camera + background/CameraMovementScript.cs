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
        if(transform.position.x < 0)
        {
            transform.position = new Vector3(0, 0, -10);
        }
    }
}
