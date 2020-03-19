using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    

    protected Pawn pawn;

    [Header("FSM Info")]
    public AI_STATES currentState;
    public bool seesPlayer;
    public float stateStartTime;

    [Header(("Navigation"))]
    public NavMeshAgent navMeshAgent;
    public Transform target;
    public List<Transform> patrolPoints;
    public int currentPatrolIndex = 0;
    public Transform currentPatrolPoint;


    public enum AI_STATES
    {
        Idle, Chase, Attack, Patrol
    }

    public void ChangeStates(AI_STATES newState)
    {
        currentState = newState;
        stateStartTime = Time.time;
    }

    public void Idle()
    {

    }

    public void Attack()
    {

    }

    public void Chase()
    {

    }

    public void Patrol()
    {
        target = currentPatrolPoint;
        navMeshAgent.SetDestination(target.position);

        if(Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < .5f)
        {
            if (currentPatrolIndex + 1 < patrolPoints.Count)
            {
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }

            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }
    }

    protected virtual void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        pawn = gameObject.GetComponent<Pawn>();
        target = GameObject.Find("Player").GetComponent<Transform>();
    }
    protected virtual void Update()
    {
        navMeshAgent.SetDestination(target.position);
        pawn.HandleEnemyMovement();
    }

    protected void OnAnimatorMove()
    {
        navMeshAgent.velocity = pawn.anim.velocity;
    }
}
