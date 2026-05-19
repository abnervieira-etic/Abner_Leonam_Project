using UnityEngine;

public class Kick : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Idle");
    }
    void Update()
    {
        doKick();
    }
    void doKick()
    {
        if (Input.GetKeyDown(KeyCode.J))
            {
                animator.SetTrigger("Kick");
                print("triggered");
            }
        else 
            {
                animator.SetTrigger("Idle");
            }
    }
}
