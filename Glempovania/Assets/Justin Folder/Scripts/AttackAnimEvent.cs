using UnityEngine;

public class AttackAnimEvent : MonoBehaviour
{
    //This is actually for all anim events, not just the attack one lol

    //Jump anim event
    void JumpEnd()
    {
        GetComponent<Animator>().SetBool("Jump", false);
    }


    //Attack anim event reader
    void AttackDone()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        //Debug.Log("Attack Done");
    }
}
