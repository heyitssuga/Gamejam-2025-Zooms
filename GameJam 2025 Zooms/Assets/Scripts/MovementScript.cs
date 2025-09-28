using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{

    private InputAction moveAction;
    private Vector3 position;
    public float speed = 5f;
    [SerializeField] private Animator animator;
    private bool isFacingRight, isOnBorder;
    [SerializeField] private CameraMovementScript camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions["Move"];
        isFacingRight = true;
        isOnBorder = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        position = this.gameObject.transform.position;
        float movement = Time.deltaTime * speed;
        this.gameObject.transform.Translate(new Vector3(moveAction.ReadValue<Vector2>().x * movement, moveAction.ReadValue<Vector2>().y * movement), 0);

        if (moveAction.ReadValue<Vector2>().x > 0 && !isFacingRight)
        {
            isFacingRight = true;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (moveAction.ReadValue<Vector2>().x < 0 && isFacingRight)
        {
            isFacingRight = false;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        if (transform.position.y > 8.4f)
        {
            transform.position = new Vector3(transform.position.x, 8.4f, transform.position.z);
            isOnBorder = true;
        }
        else if (transform.position.y <= -26.5f)
        {
            transform.position = new Vector3(transform.position.x, -26.5f, transform.position.z);
            isOnBorder = true;
        }
        else
        {
            isOnBorder = false;
        }

        if (!camera.isFollowing)
        {
            Vector3 camPos = camera.transform.position;
            if(transform.position.x - -53.8f < camPos.x)
            {
                transform.position = new Vector3(camPos.x - 53.8f, transform.position.y, transform.position.z);
                isOnBorder = true;
            }
        }

        if (position == transform.position && !isOnBorder)
        {
            animator.SetBool("IsMoving", false);
        } 
        else
        {
            animator.SetBool("IsMoving", true);
        }
    }
}
