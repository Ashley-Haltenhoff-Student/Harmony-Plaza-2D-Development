using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;

    [SerializeField] private Vector3[] possibleActions;
    public bool[] isNotAvailableActions;

    private Vector3 normalizedMovement;
    private Vector3 forwardVector;
    private Vector3 rightVector;
    public Vector3 target;

    private int lastPositionIndex;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        isNotAvailableActions = new bool[possibleActions.Length];
        SetTargetPosition();
    }

    void Update()
    {
        if (transform.position.x == target.x && Mathf.Abs(transform.position.y - target.y) < 0.001)
        {
            print("has the same y coord");
            isNotAvailableActions[lastPositionIndex] = true;
            SetTargetPosition();
        }
        Animate();
        SetAgentPosition();
    }

    private void SetTargetPosition()
    {
        //int rnd = Random.Range(0, CheckAvailablePoints().Length);
        int rnd = Random.Range(0, possibleActions.Length);

        lastPositionIndex = rnd;
        target = GetAction(rnd);
    }

    private void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

    private void Animate()
    {
        normalizedMovement = agent.desiredVelocity.normalized;
        //forwardVector = Vector3.Project(normalizedMovement, transform.up);
        rightVector = Vector3.Project(normalizedMovement, transform.right);

        //if (forwardVector.y > 0.9f) { animator.SetBool("Up", true); }
        //else { animator.SetBool("Up", false); }

        //if (forwardVector.y < System.Math.Abs(-0.08f)) { animator.SetBool("Down", true); }
        //else { animator.SetBool("Down", false); }

        if (rightVector.x > 0) { animator.SetBool("Right", true); }
        else { animator.SetBool("Right", false); }

        if (rightVector.x < 0) { animator.SetBool("Left", true); }
        else { animator.SetBool("Left", false); }
    }

    private Vector3 GetAction(int rndNum)
    {
        //Vector3[] availablePoints = CheckAvailablePoints();
        isNotAvailableActions[rndNum] = false;
        //return availablePoints[rndNum];
        return possibleActions[rndNum];
    }

    private Vector3[] CheckAvailablePoints()
    {
        int num = 0-1;
        foreach (bool boolean in isNotAvailableActions) { if (boolean == false) { num++; } }

        Vector3[] availablePoints = new Vector3[num];
        int num2 = 0;

        for (int i = 0; i < possibleActions.Length; i++)
        {
            if (isNotAvailableActions[i] == false) { availablePoints[num] = possibleActions[i]; num2++; }
        }
        return availablePoints;
    }
}
