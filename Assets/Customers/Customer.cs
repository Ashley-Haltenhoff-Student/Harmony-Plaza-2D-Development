using HarmonyPlaza;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;

    [SerializeField] private Vector3[] possibleActions;
    [SerializeField] private Vector3[] chosenActions;

    private Vector3 normalizedMovement;
    private Vector3 rightVector;
    public Vector3 target;

    private bool canLeavePosition = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
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
            if (Mathf.Abs(transform.position.x - target.x) < 0.001
                && Mathf.Abs(transform.position.y - target.y) < 0.001)
            {
                int rnd = Random.Range(0, 6);
                StartCoroutine(StayInPosition(rnd));
                if (!canLeavePosition) { yield return null; }
            }
        }
        Leave();
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

    private IEnumerator StayInPosition(int seconds)
    {
        canLeavePosition = false;
        yield return new WaitForSeconds(seconds);
        canLeavePosition = true;
    }

    private void CheckOutAtRegister()
    {
        target = new Vector3(23, 26, 0);
    }

    private IEnumerator Leave()
    {
        target = new Vector3(26, 24, 0);
        if (Mathf.Abs(transform.position.x - target.x) < 0.001
                && Mathf.Abs(transform.position.y - target.y) < 0.001)
        {
            Destroy(gameObject);
        }
        else { yield return null; }
    }
}
