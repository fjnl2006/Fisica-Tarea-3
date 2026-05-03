using UnityEngine;
using UnityEngine.InputSystem;

public class Fuerza : MonoBehaviour
{
    Rigidbody rb;

    public float parametro;

    public float g;

    public float masa;
    
    public float radio;
    public bool salto;
    public bool moving;
    public Transform planeta;

    public float speed;

    private Vector2 move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =  GetComponent<Rigidbody>();
         radio = Mathf.Sqrt((transform.position.x - planeta.position.x) * (transform.position.x - planeta.position.x) + (transform.position.y - planeta.position.y) * (transform.position.y - planeta.position.y) + (transform.position.z - planeta.position.z) * (transform.position.z - planeta.position.z) );
         Debug.Log(radio);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 gravity = (Vector3.down * g * rb.mass * masa) / (radio * radio);
        rb.AddForce( gravity);
        
        if (moving)
        {
            Debug.Log(gravity.magnitude);
            rb.AddForce(Vector3.up * parametro);
        }

        if (moving)
        {
            rb.linearVelocity = new Vector3(move.x, 0, move.y) * speed ;
        }
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            salto = true;
            Debug.Log("Salto");
        }
        else if (context.canceled)
        {
            salto = false;
            Debug.Log("No salto");
        }
    }

     public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        if (context.started || context.performed)
        {
            moving = true;
            Debug.Log("Movimiento");
        }
        else if (context.canceled)
        {
            moving = false;
            Debug.Log("No movimiento");
        }
    }
}
