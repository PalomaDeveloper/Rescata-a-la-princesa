using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float right;
    public float left;
    public bool moving;
    private SpriteRenderer sprite;
    public Collider2D col;
    public Movement player;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (transform.position.x >= right ) 
        {
            moving = true;
            Derecha();
        }else if (transform.position.x <= left)
        {
            moving = false;
            Izquierda();
        }else if(transform.position.x > left && transform.position.x < right && moving == true)
        {
            Derecha();
        }else if(transform.position.x < right && transform.position.x > left && moving == false )
        {
            Izquierda();
        }

    }

    void Derecha()
    {
        transform.position = transform.position + new Vector3(-movementSpeed * Time.deltaTime, 0 , 0);
        sprite.flipX = true;    
    }
    void Izquierda()
    {
        transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0 , 0);
        sprite.flipX = false;    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.Daño();
        }
    }
}
