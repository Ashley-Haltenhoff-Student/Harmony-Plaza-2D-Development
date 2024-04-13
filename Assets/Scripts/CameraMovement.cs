using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] PlayerMovement player;

    private Vector3 offset = new Vector3(0f, 0f, -8f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    private bool canMove = true;

    private void Update()
    {
        if (canMove == false) { }
        else
        {
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, -12) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, player.speed);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MallBorder"))
        {
            canMove = false;
            print("collided with " + collision.gameObject);
        }
    }

    
}
