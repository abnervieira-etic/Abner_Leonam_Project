using System.Collections;
using UnityEngine;

public class Modifiers : MonoBehaviour
{
    [SerializeField] float modifierDuration = 5f;
    [SerializeField] string modifierType;
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    private int secondsBFSpawn;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Randomizer();
    }

    void Update()
    {
        //random movement of the modifier
        rb.MovePosition(Vector2.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1)));
        
    }

    void Randomizer()
    {
        secondsBFSpawn = Random.Range(1, 5);
        spawnPos = Random.Range(0, 2) == 0 ? point1.position : point2.position;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            if (modifierType == "speed")
            {
                StartCoroutine(Speed());
            }

            if (modifierType == "fly")
            {
                Player1.P1instance.StartCoroutine(Player1.P1instance.Fly());
            }

            ObjectPooler.Instance.ReturnObject(gameObject);
        }
    }

    
    
    IEnumerator SpawnSystem()
    {
        yield return new WaitForSeconds(secondsBFSpawn);
        ObjectPooler.Instance.PullObject(spawnPos);
        yield return new WaitForSeconds(secondsBFSpawn);
        ObjectPooler.Instance.ReturnObject(gameObject);
    }

    IEnumerator Speed()
    {
        Time.timeScale = 2f;
        yield return new WaitForSeconds(modifierDuration);
        Time.timeScale = 1f;
    }
}
