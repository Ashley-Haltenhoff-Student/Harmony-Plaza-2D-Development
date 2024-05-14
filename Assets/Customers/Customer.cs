using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    private Vector3 target;

    private Vector3 normalizedMovement;
    private Vector3 forwardVector;
    private Vector3 rightVector;

    [SerializeField] Vector3[] possibleActions;
    [SerializeField] string[] possibleActionNames;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        SetTargetPosition();

        Animate();

        SetAgentPosition();
    }

    private void SetTargetPosition()
    {
        int rnd = Random.Range(1, possibleActions.Length);
        print(gameObject.name + " = " + GetActionName(rnd));

        target = GetAction(rnd);
    }

    private Vector3 GetAction(int rndNum) { return possibleActions[rndNum - 1]; }
    private string GetActionName(int rndNum) { return possibleActionNames[rndNum - 1]; }

    private void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

    private void Animate()
    {
        normalizedMovement = agent.desiredVelocity.normalized;
        forwardVector = Vector3.Project(normalizedMovement, transform.up);
        rightVector = Vector3.Project(normalizedMovement, transform.right);

        if (forwardVector.y > 0.10f) { animator.SetBool("Up", true); }
        else { animator.SetBool("Up", false); }

        if (forwardVector.y < -0.10f) { animator.SetBool("Down", true); }
        else { animator.SetBool("Down", false); }

        if (rightVector.x > 0) { animator.SetBool("Right", true); }
        else { animator.SetBool("Right", false); }

        if (rightVector.x < 0) { animator.SetBool("Left", true); }
        else { animator.SetBool("Left", false); }
    }

}
