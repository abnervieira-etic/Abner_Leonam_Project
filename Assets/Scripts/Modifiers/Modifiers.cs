using System.Collections;
using UnityEngine;

public class Modifiers : MonoBehaviour
{
    [SerializeField] float modifierDuration = 10f;
    [SerializeField] string modifierType;
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
 
    [SerializeField] private float moveAmount = 0.3f;
    [SerializeField] private float moveSpeed = 2f;
    public bool isFlying;

    private Vector2 direction;
    private float startY;
    public static Modifiers instance;
    public bool canStrike2X = false;

    private void OnEnable()
    {   
        instance = this;
        direction = Random.insideUnitCircle.normalized;
        startY = transform.position.y;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = true;
    }

    void Update()
    {
        
        float newY = startY + Mathf.Sin(Time.time * moveSpeed) * moveAmount;

        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, 0);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"P1instance: {Player1.P1instance}");
        Debug.Log($"P2instance: {Player1.P2instance}");

        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2") || collision.gameObject.CompareTag("Ball"))
        {
           UImanager.instance.CallModifierTxt(modifierType, modifierDuration);

            switch(modifierType)
            {
                case "2XSPEED":
                OBJpooler.Instance.StartCoroutine(SpeedRoutine(modifierDuration * 1.5f));
                break;
                case "FLY":
                Player1.P1instance.StartCoroutine(Fly());
                break;
                case "SMALL":
                Player1.P1instance.StartCoroutine(Small());
                break;
                case "BIGPLAYERS":
                Player1.P1instance.StartCoroutine(Big());
                break;
                case "INVISIBLE":
                Player1.P1instance.StartCoroutine(Invisible());
                break;
            }

            OBJpooler.Instance.ReturnObject(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            direction = Vector2.Reflect(direction, -direction).normalized;
            startY = transform.position.y;
        }
    }

    IEnumerator SpeedRoutine(float modifierDuration)
    {
        Time.timeScale = 1.5f;
        yield return new WaitForSeconds(modifierDuration * 1.5f);
        Time.timeScale = 1f;

    }

    IEnumerator Fly()
    {
    toFly(true);
    yield return new WaitForSeconds(modifierDuration);
    toFly(false);
    }

    void toFly(bool flying)
    {

    float jumpForce;

    if (flying)
        jumpForce = modifierDuration;
    else
        jumpForce = 6f;

    Player1.P1instance.Grounded = flying;
    Player1.P2instance.Grounded = flying;
    Player1.P1instance.Flying = flying;
    Player1.P2instance.Flying = flying;
    Player1.P1instance.MaxJumpForce = jumpForce;
    Player1.P2instance.MaxJumpForce = jumpForce;

    isFlying = flying;
    }

     IEnumerator Small()
     {
         Player1.P1instance.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
         Player1.P2instance.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
         yield return new WaitForSeconds(modifierDuration);
         Player1.P1instance.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
         Player1.P2instance.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
     }

     IEnumerator Big()
     {
         Player1.P1instance.transform.localScale = new Vector3(2.5f, 2.5f, 1f);
         Player1.P2instance.transform.localScale = new Vector3(2.5f, 2.5f, 1f);
         yield return new WaitForSeconds(modifierDuration);
         Player1.P1instance.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
         Player1.P2instance.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
     }

     IEnumerator Invisible()
     {
         Player1.P1instance.GetComponent<SpriteRenderer>().enabled = false;
         Player1.P2instance.GetComponent<SpriteRenderer>().enabled = false;
         Player1.P1instance.leg.enabled = false;
         Player1.P2instance.leg.enabled = false;
         yield return new WaitForSeconds(modifierDuration);
         Player1.P1instance.GetComponent<SpriteRenderer>().enabled = true;
         Player1.P2instance.GetComponent<SpriteRenderer>().enabled = true;
         Player1.P1instance.leg.enabled = true;
         Player1.P2instance.leg.enabled = true;
     }
    
  
}
