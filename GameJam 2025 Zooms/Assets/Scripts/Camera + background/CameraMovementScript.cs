using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;
    [SerializeField] private CheckPointEnemyManager checkPoint;
    public bool isFollowing = true;
    public bool isOnCheckPoint = false;
    private bool update1stCheckPoint = false;
    private bool update2stCheckPoint = false;
    private bool update3stCheckPoint = false;
    private bool update4stCheckPoint = false;
    private Vector3 newPosition;

    private void FixedUpdate()
    {
        Vector3 targetPosition = playerTransform.position + offset;
        
        if(isFollowing)
        {
            transform.position = new Vector3(targetPosition.x, 0, -10);
        }


        if(transform.position.x < 0 && !checkPoint.checkPoint1Done)
        {
            transform.position = new Vector3(0, 0, -10);
            isFollowing = false;
        }
        if (checkPoint.checkPoint1Done && !checkPoint.checkPoint2Done && isOnCheckPoint)
        {
            if (!update1stCheckPoint)
            {
                newPosition = transform.position;
                update1stCheckPoint = true;
            }
            transform.position = newPosition;

            isFollowing = false;
            isOnCheckPoint = true;
        }
        else if (checkPoint.checkPoint2Done && !checkPoint.checkPoint3Done && isOnCheckPoint)
        {
            if (!update2stCheckPoint)
            {
                newPosition = transform.position;
                update2stCheckPoint = true;
            }
            transform.position = newPosition;

            isFollowing = false;
            isOnCheckPoint = true;
        }
        else if (checkPoint.checkPoint3Done && !checkPoint.checkPoint4Done && isOnCheckPoint)
        {
            if (!update3stCheckPoint)
            {
                newPosition = transform.position;
                update3stCheckPoint = true;
            }
            transform.position = newPosition;
            isFollowing = false;
            isOnCheckPoint = true;
        }
        else if (checkPoint.checkPoint4Done && isOnCheckPoint)
        {
            if (!update4stCheckPoint)
            {
                newPosition = transform.position;
                update4stCheckPoint = true;
            }
            transform.position = newPosition;
            isFollowing = false;
            isOnCheckPoint = true;
        }
        else
        {
            isFollowing = true;
        }
    }
}
