using UnityEngine;

public class AttackAnimEvent : MonoBehaviour
{
    void AttackDone()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        Debug.Log("Attack Done");
    }
}
