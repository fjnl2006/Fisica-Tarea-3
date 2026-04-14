using UnityEngine;

public class Fuerza : MonoBehaviour
{
    Rigidbody rb;

    public float parametro;

    public float g;

    public float masa;
    
    public float radio;

    public Transform planeta;   
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
        Debug.Log(gravity.magnitude);
        rb.AddForce(Vector3.up * parametro);
    }
}
