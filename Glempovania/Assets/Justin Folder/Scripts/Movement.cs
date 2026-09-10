

using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
//private float MoveHort
public class Movement : MonoBehaviour
{
    public Rigidbody rb;

    public PlayerInput playerInput;
  
    private float inputMovement;//move left and right lmao
    private float inputJump;
    public float speedX;
    public float speedY;
    bool jumping = false;
    // float maxSpeed;
    // float currentspeed;
    // float maxAccel;
    // float currentAccel;
    // float deccel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    { 
        rb.linearVelocity = new Vector3(speedX * inputMovement, rb.linearVelocity.y, rb.linearVelocity.z);
        if (inputMovement == 0)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, rb.linearVelocity.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Best practice for checking tags
        {
            jumping = false;
            Debug.Log("Player has landed on the floor!");
        }
    }

    void OnMovement(InputValue input)
    {
        inputMovement = input.Get<float>();
        Debug.Log(input.Get<float>());
    }
    public void OnJump(InputValue input)
    {
        inputJump = input.Get<float>();
        if (jumping == false)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, speedY * inputJump, rb.linearVelocity.z);
            jumping = true;
        }
        Debug.Log("Jumped");
    }
}
