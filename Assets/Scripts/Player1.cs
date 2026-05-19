using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Rigidbody2D rb1; 
    [SerializeField] Animator animator;
    [SerializeField] float maxJumpForce = 10f;
    [SerializeField] float minJumpForce = 1.5f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float distance = 1f;
    private bool isGrounded;
    private float jumpChargeRate = 20f;
    float moveX;
    float currentJumpForce;
    bool isJumping;
    [SerializeField] private Vector3 p1pos;
    public static Player1 P1instance;

    void Awake()
    {
        p1pos = new Vector3(-6.986f, -2.23944f, 0);
    }
    void Start()
    {   

        P1instance = this;
        rb1 = GetComponent<Rigidbody2D>();       
        moveX = Input.GetAxis("Horizontal");

        transform.position = p1pos;
    }

    public void ResetPos()
    {
        transform.position = p1pos;
    }

    void Update()
    {
        IsGrounded();
        ChargeJump();
    }

    void IsGrounded()
    {                       
       isGrounded = Physics2D.Raycast(transform.position,Vector2.down,distance, whatIsGround);
    }
    void OnDrawGizmos()
    {
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down*distance);

    }

    void ChargeJump()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            isJumping = true;
            currentJumpForce = minJumpForce;
        }

        if (Input.GetKey(KeyCode.H) && isJumping)
        {
            currentJumpForce += jumpChargeRate * Time.deltaTime;
            currentJumpForce = Mathf.Clamp(currentJumpForce, minJumpForce, maxJumpForce);

            
        }

        if (Input.GetKeyUp(KeyCode.H) && isJumping)
        {
            Jump();
            isJumping = false;
        }
    }

    void Jump()
    {
        if (!isGrounded) return;
        rb1.AddForce(Vector2.up * currentJumpForce, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
       if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }
        else
        {
            moveX = 0f;
        }
        rb1.linearVelocityX = moveX * speed; 
    }

}
