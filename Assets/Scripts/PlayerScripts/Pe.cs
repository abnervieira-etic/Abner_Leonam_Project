using UnityEngine;

public class Pe : MonoBehaviour
{
    int force;
    void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.CompareTag("Ball") && gameObject.CompareTag("Foot"))
        {
            if (BallSpawner.Ballinstance.index == 0)
                force = Random.Range(-20, -25);
            else if (BallSpawner.Ballinstance.index == 1)
                force = Random.Range(-25, -30);
            else if (BallSpawner.Ballinstance.index == 2)
                force = 1;
            
        Vector2 direcao = (collision.transform.position - transform.root.position).normalized;
        direcao = new Vector2(direcao.x, 0.4f).normalized; 

        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direcao * force , ForceMode2D.Impulse); // multiplica a força
        }
    }

}
