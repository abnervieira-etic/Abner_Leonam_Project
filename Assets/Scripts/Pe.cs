using UnityEngine;

public class Pe : MonoBehaviour
{
    int forca;

    void Awake()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if (BallSpawner.Ballinstance.index == 0)
                forca = Random.Range(15, 18);
            else if (BallSpawner.Ballinstance.index == 1)
                forca = Random.Range(20, 25);
            else if (BallSpawner.Ballinstance.index == 2)
                forca = 1;
            
            print("balllllllll");
            
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-collision.GetContact(0).normal * forca, ForceMode2D.Impulse);
        }
    }

}
