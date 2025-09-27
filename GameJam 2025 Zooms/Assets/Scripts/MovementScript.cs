using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{

    private InputAction moveAction;
    private Vector3 position;
    public float speed = 5f;
    [SerializeField] private Animator animator;
    private bool isFacingRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions["Move"];
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
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
        }
        else if (transform.position.y < -26.5f)
        {
            transform.position = new Vector3(transform.position.x, -26.5f, transform.position.z);

        }

        if (position == transform.position)
        {
            animator.SetBool("IsMoving", false);
        } 
        else
        {
            animator.SetBool("IsMoving", true);
        }
    }
}
