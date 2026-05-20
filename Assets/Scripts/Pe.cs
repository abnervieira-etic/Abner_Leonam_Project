using UnityEngine;

public class Pe : MonoBehaviour
{

    [SerializeField] float forca = 20f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {

            
            print("balllllllll");
            
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-collision.GetContact(0).normal *forca,ForceMode2D.Impulse);
        }
    }
}
