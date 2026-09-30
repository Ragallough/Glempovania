using UnityEngine;

public class swordCollision : MonoBehaviour
{
    public GameObject glempoAnimator;
    public GameObject flier;
    public GameObject walker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collision)
    {
        if (glempoAnimator.gameObject.GetComponent<Animator>().GetBool("Attack") == true)
        {
            if (collision.gameObject.CompareTag("EnemyFlier"))
            {
                flier.gameObject.GetComponent<EnemyHealth>().flierHealth -= 1;
            }
            if (collision.gameObject.CompareTag("Enemywalker"))
            {
                flier.gameObject.GetComponent<EnemyHealth>().walkerHealth -= 1;
            }
        }
    }
}
