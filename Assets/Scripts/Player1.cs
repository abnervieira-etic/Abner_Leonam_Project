
using System.Collections;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Rigidbody2D rb1; 
    [SerializeField] Animator animator;
    [SerializeField] float maxJumpForce = 5f;
    [SerializeField] float minJumpForce = 1.5f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float distance = 1f;
    private bool isGrounded;
    public bool Grounded => isGrounded;
    private float jumpChargeRate = 10f;
    float moveX;
    float currentJumpForce;
    bool isJumping;
    private Vector3 pPos;
    public static Player1 P1instance;
    public static Player1 P2instance;

    public int player;
    public Vector3 spawnPos;

    public KeyCode jumpKey = KeyCode.H;
    public bool canMove;
    void Awake()
    {
        pPos = spawnPos;
        
        if (player == 1) P1instance = this;
        else if (player == 2) P2instance = this;
    }
    void Start()
    {   
        canMove = true;
        P1instance = this;
        rb1 = GetComponent<Rigidbody2D>();       
        

        transform.position = pPos;

        if (player == 1) P1instance = this;
        else if (player == 2) P2instance = this;
    }

    public void ResetPos()
    {
        StartCoroutine(BlockMove());
        rb1.linearVelocity = Vector2.zero;
        transform.position = pPos;
    }

    IEnumerator BlockMove()
    {
        canMove = false;
        yield return new WaitForSeconds(2f);
        canMove = true;
    }
    void Update()
    {
        IsGrounded();
        ChargeJump();
    }

    void IsGrounded()
    {                       
       isGrounded = Physics2D.Raycast(transform.position,Vector2.down,distance, whatIsGround);

       if (isGrounded)
       {
           currentJumpForce = minJumpForce;
       }
    }
    void OnDrawGizmos()
    {
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down*distance);

    }


    void ChargeJump()
    {

    if (Input.GetKeyDown(jumpKey) && isGrounded)
    {
        isJumping = true;
        Jump();
    }

    // Enquanto segura, adiciona força extra progressivamente
    if (Input.GetKey(jumpKey) && isJumping)
    {
        currentJumpForce += jumpChargeRate * Time.deltaTime;
        currentJumpForce = Mathf.Clamp(currentJumpForce, minJumpForce, maxJumpForce);

        rb1.linearVelocityY = currentJumpForce; 
        
        if (currentJumpForce >= maxJumpForce)
        {
            isJumping = false;
        }
    }

    if (Input.GetKeyUp(jumpKey))
    {
        isJumping = false;
    }
    }

    void Jump()
    {
        rb1.AddForce(Vector2.up * minJumpForce, ForceMode2D.Impulse);
    }


    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (!canMove) return;
        rb1.linearVelocityX = Input.GetAxis("Horizontal"+player) * speed; 
    }

    #region Modifiers
    public IEnumerator Fly()
    {
        isGrounded = true;
        maxJumpForce = 10f;
        yield return new WaitForSeconds(5f);
        maxJumpForce = 5f;
        isGrounded = false;
    }
    
    

    #endregion
}