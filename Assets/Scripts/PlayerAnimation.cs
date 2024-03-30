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

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Right", true);
            playerMovement.PlayerWalk();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Right", false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Up", true);
            playerMovement.PlayerWalk();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Up", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Left", true);
            playerMovement.PlayerWalk();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Left", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Down", true);
            playerMovement.PlayerWalk();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Down", false);
        }


    }

}
