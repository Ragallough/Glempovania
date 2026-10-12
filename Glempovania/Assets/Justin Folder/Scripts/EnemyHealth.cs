using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int flierHealth = 2;
    public int walkerHealth = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flierHealth = 2;
        walkerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("FlierHealth:" + flierHealth);
        if (this.gameObject.name == "Flier")
        {
            if (flierHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.name == "Walker")
        {
            if (walkerHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
