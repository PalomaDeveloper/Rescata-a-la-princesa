using UnityEngine;

public class Palanca : MonoBehaviour
{
    public GameObject E;
    private Collider2D collider2d;
    public bool On = false;
    private Animator anim;
    public Animator animDoor;
    public Animator animDoor2;
    public Collider2D colDoor;
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (On == true) return;
            E.SetActive(true);
            Debug.Log("Player entro");
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                On = true;
                animDoor.SetBool("Abierta", true);
                animDoor2.SetBool("Abierta", true);
                colDoor.enabled = false;
                anim.SetBool("Activado", true);
                E.SetActive(false);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            E.SetActive(false);
            Debug.Log("Player salio");
        }
    }
}
