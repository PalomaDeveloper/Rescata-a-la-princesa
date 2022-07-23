using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PalancaPinchos : MonoBehaviour
{
    public bool On = false;
    public GameObject E;
    public GameObject spike; 
    private Animator anim;
    public Animator animSkeleton;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (spike.transform.position.y <= -2.25 ) 
        {
            spike.gameObject.SetActive(false);
            animSkeleton.SetBool("die", true);
        }
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
                anim.SetBool("Activado", true);
                E.SetActive(false);
                StartCoroutine(WIN());
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            E.SetActive(false);
        }
    }

    IEnumerator WIN()
    {
        yield return new WaitForSeconds (2.0f);
        SceneManager.LoadScene("Win");
    }
}
