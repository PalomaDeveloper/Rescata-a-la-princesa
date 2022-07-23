using UnityEngine;

public class spike : MonoBehaviour
{
    public PalancaPinchos palanca;

    void Update()
    {
        if (palanca.On == true)
        {
            transform.position = transform.position + new Vector3(0, -4 * Time.deltaTime , 0);
        }
    }
}
