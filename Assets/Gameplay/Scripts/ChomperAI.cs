using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ChomperAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    [SerializeField] private Transform currentPoint;
    [SerializeField] private Transform wayPointOne;
    [SerializeField] private Transform wayPointTwo;
    [SerializeField] private bool targetDetected = false;
    [SerializeField] private Transform target;


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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            targetDetected = true;
            target = collider.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            targetDetected = false;
            target = collider.transform;
        }
    }

    private void Update()
    {
        if (!targetDetected)
        {
            animator.SetBool("TargetDetected", false);
            navMeshAgent.speed = 1F;
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
        }
        else
        {
            currentPoint = target;
            animator.SetBool("TargetDetected", true);
            navMeshAgent.speed = 3.5F;
            navMeshAgent.SetDestination(currentPoint.position);
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
