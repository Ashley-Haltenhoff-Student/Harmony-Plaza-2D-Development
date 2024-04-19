using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            print("Collided with Camera");
        }
    }
}
