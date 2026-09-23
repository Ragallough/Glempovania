using UnityEngine;


public class FlyerLogic : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    public float bounceDirection;
    public float bounceForce = 5;
    public float clock = 0;

    public bool invader = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(clock);
        if (invader == true)
        {
            if (clock >= 1)
            {
                clock -= Time.deltaTime;
            }
            if (clock <= 1)
            {
                rb.linearVelocity = Vector3.zero;
                transform.position = Vector3.MoveTowards(this.transform.position, player.gameObject.GetComponent<Transform>().position, 3 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(this.transform.position, player.gameObject.GetComponent<Transform>().position, 3 * Time.deltaTime);
            }
        }
        // if (clock == 0)
        // {
        //transform.position = Vector3.MoveTowards(this.transform.position, player.gameObject.GetComponent<Transform>().position, 3 * Time.deltaTime);
        // }
        // if (clock ==1)
        // {
            
            //transform.position = Vector3.MoveTowards(this.transform.position, , 3 * Time.deltaTime);
        //}
        // if (this.transform.position.x >= player.gameObject.GetComponent<Transform>().position.x)
        // {
            
        // }
    }
    public void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.CompareTag("Player") && this.transform.position.x >= player.gameObject.GetComponent<Transform>().position.x)
        // {
        //     //this.rb.linearVelocity = new Vector3(5,3,0);
        //     //add a timer later
        // }
        // if (collision.gameObject.CompareTag("Player") && this.transform.position.x <= player.gameObject.GetComponent<Transform>().position.x)
        // {
            //this.rb.linearVelocity = new Vector3(-5,3,0);
            // Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
            // rb.AddForce(pushDirection * bounceForce, ForceMode.Impulse);
            //clock = 1;
            //Debug.Log(clock);
        //}
        Vector3 bounceDirection = (transform.position - collision.transform.position).normalized;
            
        // Keep the bounce flat on the horizontal plane (optional, keeps Y stable)
        bounceDirection.y = 0.2f; 

            // Apply force impulse to bounce away
            rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
            clock = 3;
    }
}
