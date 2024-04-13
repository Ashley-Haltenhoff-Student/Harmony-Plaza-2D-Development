using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;


    public void Walk(Vector3 direction)
    {
        transform.position += speed * Time.deltaTime * direction;
    }
}
