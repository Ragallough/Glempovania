using UnityEditor;
using UnityEngine;

public class swordCollision : MonoBehaviour
{
    public GameObject glempoAnimator;
    public GameObject flier;
    public GameObject walker;
    float clock;
    private bool hit = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hit == true)
        {
            clock -= Time.deltaTime;
            if (clock <= 0)
            {
                hit = false;
            }
            //Debug.Log("clock:" + clock);
            //Debug.Log("EnemyHealth" + flier.gameObject.GetComponent<EnemyHealth>().flierHealth);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (glempoAnimator.gameObject.GetComponent<Animator>().GetBool("Attack") == true)
        {
            if (collision.gameObject.CompareTag("EnemyFlier") && hit == false)
            {
                flier.gameObject.GetComponent<EnemyHealth>().flierHealth -= 1;
                
                hit = true;
                clock = 1f;
            }
            if (collision.gameObject.CompareTag("Enemywalker"))
            {
                flier.gameObject.GetComponent<EnemyHealth>().walkerHealth -= 1;
            }
        }
    }
}
