using UnityEngine;

public class FlierAggroLogic : MonoBehaviour
{
    public GameObject flier;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
        {
            
            flier.gameObject.GetComponent<FlyerLogic>().invader = true;
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == player)
        {
            
            flier.gameObject.GetComponent<FlyerLogic>().invader = false;
        }
    }
}
