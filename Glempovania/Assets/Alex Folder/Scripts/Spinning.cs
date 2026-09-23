using UnityEngine;

public class Spinning : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = .01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotateSpeed != 0f)
        {
            this.gameObject.transform.RotateAround(this.transform.position, transform.up, rotateSpeed);
        }
    }
}
