using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public CharacterController2D controller;
    protected int health = 60;
    protected float speed = 140f;
    float horizontalMove = 0f;
    protected bool jump = false;

    protected float force;
    public Animator animator;
    protected bool preventMoving = false;

    public Transform wallCheck;
    private RaycastHit2D wallCheckHit;
    public float wallCheckDistance;
    private bool isWallSliding = false;
    public Rigidbody2D rb;
    //public float maxWallSlidingVelocity;

    //public bool isGrounded;
    //public Transform groundCheck;
    //public float groundCheckRadius;
    public LayerMask whatIsGround;

    private GameMaster gm;

    // Start is called before the first frame update
    protected void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        //controller = gameObject.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    protected void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        animator.SetBool("isGrounded", controller.m_Grounded);
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            //isGrounded = false;            
        }

        //Check wall sliding
        
        //if (wallCheckHit && rb.velocity.y <= 0 && !controller.m_Grounded)
        //{
        //    isWallSliding = true;
        //}
        //else
        //{
        //    isWallSliding = false;
        //}
        if(gameObject == null)
        {

        }
    }

    protected void FixedUpdate()
    {
        //checkSurroundings();
        if (preventMoving == false)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
        wallCheckHit = Physics2D.Raycast(wallCheck.position, wallCheck.right, wallCheckDistance, whatIsGround);

        if (wallCheckHit && !controller.m_Grounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isWallJumping", true);
                rb.AddForce(new Vector2(0f, 300f));
            }
            else
            {
                animator.SetBool("isWallJumping", false);
            }
        }

        //Clamp y velocity 
        //if (wallcheckhit)
        //{
        //    if (rb.velocity.y < -maxwallslidingvelocity)
        //    {
        //        rb.velocity = new vector2(rb.velocity.y, -maxwallslidingvelocity);
        //    }
        //}
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isWallJumping", false);
    }

    public void movingStateChanging()
    {
        preventMoving = false;
    }

    //IEnumerator jumpTimer()
    //{
    //   yield return new WaitForSeconds(0.01f);  
    //}

    //private void checkSurroundings()
    //{
    //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    //    animator.SetBool("isGrounded", isGrounded);
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    //}
}
