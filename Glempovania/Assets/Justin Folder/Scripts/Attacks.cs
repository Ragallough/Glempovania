using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attacks : MonoBehaviour
{
    public GameObject glempoAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void AttackDone()
    {
        Debug.Log("AttackDone");
    }

    void OnAttack()
    {
        glempoAnimator.gameObject.GetComponent<Animator>().SetBool("Attack", true);
        Debug.Log("Swing!");
    }
}
