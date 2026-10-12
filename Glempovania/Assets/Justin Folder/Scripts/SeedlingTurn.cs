
using UnityEditor.Callbacks;
using UnityEngine;

public class SeedlingTurn : MonoBehaviour
{
    public int speed;
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(speed, rb.linearVelocity.y, rb.linearVelocity.z);
        if (speed < 0)
        {
            rb.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(this.transform.rotation.x, -180, this.transform.rotation.z );
        }
        if (speed > 0)
        {
            rb.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(this.transform.rotation.x, 0, this.transform.rotation.z );
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SeedCollision"))
        {
            speed *= -1;
        }
    }
}
