using UnityEngine;

public class camFollow : MonoBehaviour
{
    public GameObject egg;
    Vector2 eggPosition;
    public enum MyEnumeratedType {X, Y}
    public MyEnumeratedType option;
    void Update()
    {
        switch (option)
        {
            case MyEnumeratedType.X:
            {
                eggPosition.x = egg.transform.position.x;
                break;
            }
            case MyEnumeratedType.Y:
            {
                eggPosition.y = egg.transform.position.y;
                break;
            }
        }
        transform.position = eggPosition; 
    }
}
