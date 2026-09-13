using Unity.VisualScripting;
using UnityEngine;

public class Jump_Check : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Best practice for checking tags
        {
            player.GetComponent<Movement>().jumping = false;
            Debug.Log("Player has landed on the floor!");
        }
    }
}
