using HarmonyPlaza;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


namespace HarmonyPlaza
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] NavMeshAgent agent;
        [SerializeField] Animator animator;
        [SerializeField] CashRegister cashRegister;

        [SerializeField] private Vector3[] possibleActions;
        [SerializeField] private Vector3[] chosenActions;

        private Vector3 normalizedMovement;
        private Vector3 rightVector;
        public Vector3 target;

        private bool canLeavePosition = true;
        public bool foundBook = false;
        public bool isFirstInLine = false;
        public bool isInLine = false;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            cashRegister = FindFirstObjectByType<CashRegister>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            int rnd = Random.Range(1, 5);
            chosenActions = new Vector3[rnd];
            for (int i = 0; i < chosenActions.Length; i++) 
            {
                chosenActions[i] = possibleActions[Random.Range(0, possibleActions.Length - 1)];
            }

            StartCoroutine(GoThroughTargetPositions());
        }

        void Update()
        {
            Animate();
            SetAgentPosition();
        }

        private IEnumerator GoThroughTargetPositions()
        {
            for (int i = 0; i < chosenActions.Length; i++)
            {
                target = chosenActions[i];
                while (Mathf.Abs(transform.position.x - target.x) > 0.001
                    && Mathf.Abs(transform.position.y - target.y) > 0.001) { yield return null; }

                int rnd = Random.Range(5, 11);
                yield return new WaitForSeconds(rnd);

                int rnd2 = Random.Range(1, 2);
                if (rnd2 == 1)
                {
                    foundBook = true;
                    CheckOutAtRegister();
                    yield break;
                }
                else if (!canLeavePosition) { yield return null; }

            }

            StartCoroutine(Leave());
        }

        private void SetAgentPosition()
        {
            agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
        }

        private void Animate()
        {
            normalizedMovement = agent.desiredVelocity.normalized;
            rightVector = Vector3.Project(normalizedMovement, transform.right);

            if (rightVector.x > 0) { animator.SetBool("Right", true); }
            else { animator.SetBool("Right", false); }

            if (rightVector.x < 0) { animator.SetBool("Left", true); }
            else { animator.SetBool("Left", false); }
        }

        private void CheckOutAtRegister()
        {
            for (int i = 0; i < cashRegister.customersInLine.Length; i++)
            {
                if (cashRegister.customersInLine[i] == null) 
                { 
                    cashRegister.customersInLine[i] = this;
                    target = cashRegister.linePoints[i];
                    break;
                }
            }
        }

        public IEnumerator Leave()
        {
            target = new Vector3(26, 24, 0);
        

            while (Mathf.Abs(transform.position.x - target.x) > 0.000001
                    && Mathf.Abs(transform.position.y - target.y) > 0.000001)
            {
                yield return null;
            }
                Destroy(gameObject);
                print(gameObject + " is destroyed");
        }

        public void SetTarget(Vector3 point) { target = point; }
    }

}
