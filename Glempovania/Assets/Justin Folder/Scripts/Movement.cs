

using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
//private float MoveHort
public class Movement : MonoBehaviour
{
    public Rigidbody rb;

    public PlayerInput playerInput;

    public GameObject flier;
  
    private float inputMovement;//move left and right lmao
    private float inputJump;
    public float speedX;
    public float speedY;
    public bool isGrounded = false;
    public bool trig = false;
    // float maxSpeed;
    // float currentspeed;
    // float maxAccel;
    // float currentAccel;
    // float deccel;

    LayerMask layerMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Awake()
    {
        layerMask = LayerMask.GetMask("Ground");
    }
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

        Physics.Raycast(transform.position, transform.up * -1, 1);
        if (isGrounded == Physics.Raycast(transform.position, transform.up * -1, 1))
        {
            isGrounded = false; 
            Debug.Log("raycasted");
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
        if (isGrounded == false)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, speedY * inputJump, rb.linearVelocity.z);
            isGrounded = true;
        }
        Debug.Log("Jumped");
    }

    // public void OnCollisionEnter(Collision collision)
    // {
    //    if (collision.gameObject.CompareTag("EnemyTerr"))
    //     {
    //         flier.gameObject.GetComponent<FlyerLogic>().invader = true;
    //     } 
    //     else
    //     {
    //         flier.gameObject.GetComponent<FlyerLogic>().invader = false;
    //     }
    // }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "EnemyTerr")
        {
            
            flier.gameObject.GetComponent<FlyerLogic>().invader = true;
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "EnemyTerr")
        {
            
            flier.gameObject.GetComponent<FlyerLogic>().invader = false;
        }
    }
}
