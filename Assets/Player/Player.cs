using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


namespace HarmonyPlaza { 

    [RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour
    {
        public Animator animator;
        public float speed = 10f;

        private bool canMove = true;
        private bool isColliding = false;

        void Start()
        {
            animator = GetComponent<Animator>();       
        }

        void Update()
        {

            if (Input.GetKey(KeyCode.D) && canMove)
            {
                animator.SetBool("Right", true);
                if (!isColliding) { Walk(Vector3.right); }
            }
            else
            {
                animator.SetBool("Right", false);
            }


            if (Input.GetKey(KeyCode.W) && canMove)
            {
                animator.SetBool("Up", true);
                if (!isColliding) { Walk(Vector3.up); }
            }
            else
            {
                animator.SetBool("Up", false);
            }

            if (Input.GetKey(KeyCode.A) && canMove)
            {
                animator.SetBool("Left", true);
                if (!isColliding) { Walk(Vector3.left); }
            }
            else
            {
                animator.SetBool("Left", false);
            }


            if (Input.GetKey(KeyCode.S) && canMove)
            {
                animator.SetBool("Down", true);
                if (!isColliding) { Walk(Vector3.down); }
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

        public void SetCanMove(bool boolean) { canMove = boolean; }

        //private void OnCollisionStay2D(Collision2D collision) { isColliding = true; }
        //private void OnCollisionExit2D(Collision2D collision) { isColliding = false; }
    }
}
