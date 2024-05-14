using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    private Vector3 target;

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

        if (target.y > transform.position.y) { animator.SetBool("Up", true); }
        else { animator.SetBool("Up", false); }

        if (target.y < transform.position.y) { animator.SetBool("Down", true); }
        else { animator.SetBool("Down", false); }

        if (target.x > transform.position.x) { animator.SetBool("Right", true); }
        else { animator.SetBool("Right", false); }

        if (target.x < transform.position.x) { animator.SetBool("Left", true); }
        else { animator.SetBool("Left", false); }

        SetAgentPosition();
    }

    private void SetTargetPosition() { target = Camera.main.ScreenToWorldPoint(Input.mousePosition); }

    private void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

}
