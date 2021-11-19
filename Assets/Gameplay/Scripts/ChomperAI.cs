using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChomperAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    [SerializeField] private Transform currentPoint;
    [SerializeField] private Transform wayPointOne;
    [SerializeField] private Transform wayPointTwo;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        currentPoint = wayPointOne;
        navMeshAgent.SetDestination(currentPoint.position);
    }

    private void Update()
    {
        if (AgentDone())
        {
            if (currentPoint == wayPointOne)
            {
                currentPoint = wayPointTwo;
                navMeshAgent.SetDestination(currentPoint.position);
            }
            else
            {
                currentPoint = wayPointOne;
                navMeshAgent.SetDestination(currentPoint.position);
            }
        }

        animator.SetFloat("Speed", navMeshAgent.speed);
    }

    protected bool AgentDone()
    {
        return !navMeshAgent.pathPending && AgentStopping();
    }

    protected bool AgentStopping()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance;
    }
}
