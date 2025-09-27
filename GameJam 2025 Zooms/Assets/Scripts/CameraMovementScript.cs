using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;


    private void FixedUpdate()
    {
        Vector3 targetPosition = playerTransform.position;

        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
    }
}
