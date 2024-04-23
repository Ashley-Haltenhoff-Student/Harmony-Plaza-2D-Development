using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public Animator animator;
    public float speed = 10f;

    void Start()
    {
        animator = GetComponent<Animator>();       
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true);
            Walk(Vector3.right);
        }
        else
        {
            animator.SetBool("Right", false);
        }


        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Up", true);
            Walk(Vector3.up);
        }
        else
        {
            animator.SetBool("Up", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
            Walk(Vector3.left);
        }
        else
        {
            animator.SetBool("Left", false);
        }


        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Down", true);
            Walk( Vector3.down);
        }
        else
        {
            animator.SetBool("Down", false);
        }

    }

    public void Walk(Vector3 direction)
    {
        transform.position += speed * Time.deltaTime * direction;
    }

}
