using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    #region VARIABLES
    //vidas
    public int vidas = 3;
    /// Velocity
    public float velocity = 7.0f;
    public float reduceVelocity = 7.0f;
    public float normalVelocity = 7.0f;
    public float jumpVelocity = 27.0f;
    /// <summary>
    /// Initial jump velocity at the start of a jump.
    /// </summary>
    public float jumpTakeOffSpeed = 7.0f;

    private bool stopJump;
    /*internal new*/ public Collider2D collider2d;
    public Collider2D checkGround;
    private Rigidbody2D rb;
    bool jump;
    public bool hit = false;

    public bool IsGrounded;
    Vector2 move;
    SpriteRenderer spriteRenderer;
    internal Animator animator;
    #endregion
    void Awake()
        {
            checkGround = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>(); 
            rb = GetComponent<Rigidbody2D>();
        }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector2.right * velocity * Time.deltaTime, ForceMode2D.Impulse);
            spriteRenderer.flipX = false;

        }
        else{
            animator.SetBool("moving", false);
        }

        if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
        

        if(IsGrounded == false)
        {
            velocity = reduceVelocity;
        }else{
            velocity = normalVelocity;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //col = checkGround;
        if (col.gameObject.tag == "wall")
        {
            IsGrounded = true;
            animator.SetBool("grounded", IsGrounded);
        }
        IsGrounded = true;
    }

        public void Daño(){
            animator.Play("Player-Hurt");
            vidas--;
            hit = true;
        }

    }
