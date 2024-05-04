using UnityEngine;


namespace HarmonyPlaza { 

    [RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour
    {
        public Animator animator;
        public float speed = 10f;

        private bool canMove = true;

        void Start()
        {
            animator = GetComponent<Animator>();       
        }

        void Update()
        {

            if (Input.GetKey(KeyCode.D) && canMove)
            {
                animator.SetBool("Right", true);
                Walk(Vector3.right);
            }
            else
            {
                animator.SetBool("Right", false);
            }


            if (Input.GetKey(KeyCode.W) && canMove)
            {
                animator.SetBool("Up", true);
                Walk(Vector3.up);
            }
            else
            {
                animator.SetBool("Up", false);
            }

            if (Input.GetKey(KeyCode.A) && canMove)
            {
                animator.SetBool("Left", true);
                Walk(Vector3.left);
            }
            else
            {
                animator.SetBool("Left", false);
            }


            if (Input.GetKey(KeyCode.S) && canMove)
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

        public void SetCanMove(bool boolean) { canMove = boolean; }

    }
}
