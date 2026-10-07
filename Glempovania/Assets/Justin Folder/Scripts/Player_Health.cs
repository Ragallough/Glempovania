using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Player_Health : MonoBehaviour
{
    public Texture fullhealth;
    public Texture threeQuatersFull;
    public Texture halfFull;
    public Texture quarterFull;

    public GameObject Canvas;
    public int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("PlayerHealth:" + health);
        if (health == 4)
        {
            Canvas.gameObject.GetComponent<RawImage>().texture = fullhealth;
        }
        if (health == 3)
        {
            Canvas.gameObject.GetComponent<RawImage>().texture = threeQuatersFull;
        }
        if (health == 2)
        {
            Canvas.gameObject.GetComponent<RawImage>().texture = halfFull;
        }
        if (health == 1)
        {
            Canvas.gameObject.GetComponent<RawImage>().texture = quarterFull;
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Flier")
        {
            health -=1;
        }

    }
}
