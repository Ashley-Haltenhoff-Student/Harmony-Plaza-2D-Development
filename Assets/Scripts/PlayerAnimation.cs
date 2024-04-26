using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Right", true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Right", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Left", true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Left", false);
        }
    }

}
