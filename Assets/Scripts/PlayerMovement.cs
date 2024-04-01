using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;

    private void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -12);
    }

    public void Walk(Vector3 currentPosition, Vector3 direction)
    {
        transform.position += speed * Time.deltaTime * direction;
    }
}
