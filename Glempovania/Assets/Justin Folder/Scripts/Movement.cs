using System.Runtime.CompilerServices;
using NUnit.Framework;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
//private float MoveHort
public class Movement : MonoBehaviour
{
    public Rigidbody rb;

    public PlayerInput playerInput;

    public GameObject flier;
    public GameObject glempoAnimator;
    private float inputMovement;//move left and right lmao
    private float inputJump;
    public float speedX;
    public float speedY;
    public bool isGrounded;
    //trig means triggered not trigonometry
    public bool trig = false;
    public bool canDoubleJump = false;
    public int remainingJumps = 4;

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
        if (inputMovement != 0)
        {
            rb.linearVelocity = new Vector3(speedX * inputMovement, rb.linearVelocity.y, rb.linearVelocity.z);
            glempoAnimator.gameObject.GetComponent<Animator>().SetFloat("Movement", 1);
        }
        //rb.linearVelocity = new Vector3(speedX * inputMovement, rb.linearVelocity.y, rb.linearVelocity.z);
        if (inputMovement == 0)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, rb.linearVelocity.z);
            glempoAnimator.gameObject.GetComponent<Animator>().SetFloat("Movement", 0);
        }

        //Physics.Raycast(transform.position, transform.up * -1, 1);
        if (Physics.Raycast(transform.position, transform.up * -1, 1, layerMask))
        {
            isGrounded = true; 
            remainingJumps = 3;
            //Debug.Log("raycasted");
        }
        else
        {
            isGrounded = false;
        }
//Debug.Log("RemainingJumps:"+ remainingJumps);
        

        if (isGrounded == true)
        {
            glempoAnimator.gameObject.GetComponent<Animator>().SetBool("Grounded", true);
        }
        else if (isGrounded == false)
        {
            glempoAnimator.gameObject.GetComponent<Animator>().SetBool("Grounded", false);
        }
        if (inputMovement < 0)
        {
            rb.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(this.transform.rotation.x, -180, this.transform.rotation.z );
        }
        if (inputMovement > 0)
        {
            rb.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(this.transform.rotation.x, 0, this.transform.rotation.z );
        }
        // if (jumping >= 2)
        // {
        //     //isGrounded = true;
        //     jumping = 0;
        // }
        // if (isGrounded == false && jumping == 2)
        // {
        //     jumping = 1;
        //     jumpedOnce = true;
        // }
        // if (jumpedOnce == true && jumping == 2 )
        // {
        //     isGrounded = true;
        //     jumpedOnce = false;
        //     jumping = 0;
        // }
        
        
        // if (isGrounded == false && canDoubleJump == true && jumping == 2)
        // {
        //     isGrounded = true;
        //     jumping = 0;
        // }
    }
    void OnMovement(InputValue input)
    {
        inputMovement = input.Get<float>();
        
        Debug.Log("move"+ input.Get<float>());
    }
    public void OnJump(InputValue input)
    {
        inputJump = input.Get<float>();
        // if you are on the ground and you haven't collected the double jump item
        if (isGrounded == true && canDoubleJump == false)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, speedY * inputJump, rb.linearVelocity.z);
            //isGrounded = true;
        }
        if (isGrounded == true && canDoubleJump == true)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, speedY * inputJump, rb.linearVelocity.z);
        }
        //if you aren't on the ground you collected the double jump item and the remaining amount of jumps is greater than zero
        if (isGrounded == false && canDoubleJump == true && remainingJumps > 0)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, speedY * inputJump, rb.linearVelocity.z);
            remainingJumps -= 1;
        }
        glempoAnimator.gameObject.GetComponent<Animator>().SetBool("Jump", true);
        
        // if (isGrounded == false && canDoubleJump == true && remainingJumps == 1)
        // {
        //     rb.linearVelocity = new Vector3(rb.linearVelocity.x, speedY * inputJump, rb.linearVelocity.z);
        //     remainingJumps = 0;
        // }
        
        
    }
/// <summary>
/// All this commented Code here is wrong! murder it with fire!
/// </summary>
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
        if (collision.gameObject.name == "Hamilton")
        {
            canDoubleJump = true;
            Destroy(collision.gameObject);
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
