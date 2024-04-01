using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    PlayerMovement playerMovement;

    void Start()
    {
        animator = GetComponent<Animator>();       
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true);
            playerMovement.Walk(transform.position, Vector3.right);
        }
        else
        {
            animator.SetBool("Right", false);
        }


        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Up", true);
            playerMovement.Walk(transform.position, Vector3.up);
        }
        else
        {
            animator.SetBool("Up", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
            playerMovement.Walk(transform.position, Vector3.left);
        }
        else
        {
            animator.SetBool("Left", false);
        }


        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Down", true);
            playerMovement.Walk(transform.position, Vector3.down);
        }
        else
        {
            animator.SetBool("Down", false);
        }

    }

}
