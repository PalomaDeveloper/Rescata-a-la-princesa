using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeBar : MonoBehaviour
{
    public Movement player;
    public GameObject[] vida;
    public Sprite[] heart;

    private int vidas;
    public Animator animPrincess;
    public Animator animSkeleton;
    public GameObject miniCam;

    void Update()
    {
        vidas = player.vidas;
        switch(vidas)
        {
        case 3:
            vida[2].GetComponent<Animator>().SetBool("broken", true);
            StartCoroutine(animHit());
        break;

        case 2:
            vida[1].GetComponent<Animator>().SetBool("broken", true);
            StartCoroutine(animHit());
        break;

        case 1:
            vida[0].GetComponent<Animator>().SetBool("broken", true);
            
            StartCoroutine(animHit());
        break;
        case 0:
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        break;

        }
    }

    IEnumerator animHit()
    {
        if (player.hit == true)
        {
            miniCam.SetActive(true);
            animPrincess.SetBool("hit", true);
            animSkeleton.SetBool("hit", true);
            yield return new WaitForSeconds (1.5f);
            miniCam.SetActive(false);
            animPrincess.SetBool("hit", false);
            animSkeleton.SetBool("hit", false);
            player.hit = false;
        }
    }
}
