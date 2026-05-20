
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
    private Vector3 pPos;
    public static Player1 P1instance;

    public int player;
    public Vector3 spawnPos;

    public KeyCode jumpKey = KeyCode.H;

    void Awake()
    {
        pPos = spawnPos;
    }
    void Start()
    {   

        P1instance = this;
        rb1 = GetComponent<Rigidbody2D>();       
        

        transform.position = pPos;
    }

    public void ResetPos()
    {
        transform.position = pPos;
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

        if (Input.GetKeyDown(jumpKey))
        {
            isJumping = true;
            currentJumpForce = minJumpForce;
        }

        if (Input.GetKey(jumpKey) && isJumping)
        {
            currentJumpForce += jumpChargeRate * Time.deltaTime;
            currentJumpForce = Mathf.Clamp(currentJumpForce, minJumpForce, maxJumpForce);

            
        }

        if (Input.GetKeyUp(jumpKey) && isJumping)
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


        rb1.linearVelocityX = Input.GetAxis("Horizontal"+player) * speed; 
    }

}
