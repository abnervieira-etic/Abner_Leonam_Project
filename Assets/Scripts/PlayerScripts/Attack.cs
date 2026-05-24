using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] int playerFoot;
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerFoot == 1)
        {
            if (collision.gameObject.CompareTag("Player2"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-collision.GetContact(0).normal * 100, ForceMode2D.Impulse);
            }
        }
        else if (playerFoot == 2)
        {
            if (collision.gameObject.CompareTag("Player1"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-collision.GetContact(0).normal * 100, ForceMode2D.Impulse);
            }
        }
    }
}
