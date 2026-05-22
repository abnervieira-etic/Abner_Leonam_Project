using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    public KeyCode attackKey = KeyCode.E;

    public PlayerState currentState;

    private void Update()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                if (Input.GetKeyDown(attackKey))
                {
                    currentState = PlayerState.Attack;
                    animator.SetBool("IsAttacking", true);
                }
                else if (Mathf.Abs(rb.linearVelocity.x) > 0.1f)
                {
                    currentState = PlayerState.Walk;
                    animator.SetBool("IsWalking", true);
                }
                break;
            case PlayerState.Walk:
                if (Input.GetKeyDown(attackKey))
                {
                    currentState = PlayerState.Attack;
                    animator.SetBool("IsAttacking", true);
                    animator.SetBool("IsWalking", false);
                }
                else if (Mathf.Abs(rb.linearVelocity.x) <= 0.1f)
                {
                    currentState = PlayerState.Idle;
                    animator.SetBool("IsWalking", false);
                }
                break;
            case PlayerState.Attack:
                AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                if (info.normalizedTime >= 0.9f && !animator.IsInTransition(0))
                {
                    currentState = PlayerState.Idle;
                    animator.SetBool("IsAttacking", false);
                }
                break;

        }
    }

    public enum PlayerState
    {
        Idle,
        Walk,
        Attack
    }
}
