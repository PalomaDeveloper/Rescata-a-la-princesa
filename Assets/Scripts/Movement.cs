using UnityEngine;

public class Movement : MonoBehaviour
{
    #region VARIABLES
    //vidas
    public int vidas = 3;
    // Velocity
    public float velocity = 7.0f;
    public float reduceVelocity = 7.0f;
    public float normalVelocity = 7.0f;
    //Jump
    public float jumpVelocity = 27.0f;
    public float jumpTakeOffSpeed = 7.0f;
    private bool stopJump;
    private bool jump;
    /*internal new*/ public Collider2D collider2d;
    public Collider2D checkGround;
    private Rigidbody2D rb;
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
    void Update()
    {
        if (Input.GetKey("d"))
        {
            animator.SetBool("moving", true);
            rb.AddForce(Vector2.right * velocity * Time.deltaTime, ForceMode2D.Impulse);
            spriteRenderer.flipX = false;

        }else if (Input.GetKey("a"))
        {
            animator.SetBool("moving", true);
            rb.AddForce(Vector2.right * -velocity * Time.deltaTime, ForceMode2D.Impulse);
            spriteRenderer.flipX = true;
        }
        else{
            animator.SetBool("moving", false);
        }

        if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);

        if (Input.GetKeyDown("w") && IsGrounded)
            {
                IsGrounded = false;
                rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            }
        

        if(IsGrounded == false)
        {
            velocity = reduceVelocity;
        }else{
            velocity = normalVelocity;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
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