using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public TMP_Text textCoin;
    public int numCoin; 
    public string stringCoin;
    public Collider2D col;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            stringCoin = textCoin.text;
            numCoin = int.Parse(stringCoin.Substring(1));
            numCoin++; 
            textCoin.text = "x"+ numCoin.ToString();
            anim.SetBool("taked", true);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
