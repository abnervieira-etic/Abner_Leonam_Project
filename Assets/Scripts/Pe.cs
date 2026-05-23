using UnityEngine;

public class Pe : MonoBehaviour
{
    int forca;
    void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.CompareTag("Ball") && gameObject.CompareTag("Foot"))
        {
            if (BallSpawner.Ballinstance.index == 0)
                forca = Random.Range(20, 25);
            else if (BallSpawner.Ballinstance.index == 1)
                forca = Random.Range(25, 30);
            else if (BallSpawner.Ballinstance.index == 2)
                forca = 1;
            
        Vector2 direcao = (collision.transform.position - transform.root.position).normalized;
        direcao = new Vector2(direcao.x, 0.4f).normalized; 

        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direcao * forca , ForceMode2D.Impulse); // multiplica a força
        }
    }

}
