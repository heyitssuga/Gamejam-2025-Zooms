using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{

    private InputAction moveAction;
    private Vector3 position;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        position = this.gameObject.transform.position;
        this.gameObject.transform.Translate(new Vector3(moveAction.ReadValue<Vector2>().x, moveAction.ReadValue<Vector2>().y) * Time.deltaTime * speed, 0);
        
        if(position.y > 4.5f)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 4.5f, this.gameObject.transform.position.z);
        } else if(position.y < -4.5f)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -4.5f, this.gameObject.transform.position.z);
        }

        if (position.x > 8.4f)
        {
            this.gameObject.transform.position = new Vector3(8.4f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
        else if (position.x < -8.4f)
        {
            this.gameObject.transform.position = new Vector3(-8.4f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }
}
