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
    public GameObject attackButtonObject;
    public bool isAttacking;
    public float waitTime;
    public float attackStartTime;


    [Header(("Navigation"))]
    public NavMeshAgent navMeshAgent;
    public Transform target;
    public List<Transform> patrolPoints;
    public int currentPatrolIndex = 0;
    public Transform currentPatrolPoint;


    public enum AI_STATES
    {
        Idle, Chase, Attack, Search
    }

    public void ChangeStates(AI_STATES newState)
    {
        currentState = newState;
        stateStartTime = Time.time;
    }

    public void Idle()
    {
        navMeshAgent.destination = this.gameObject.transform.position;
        pawn.anim.SetFloat("Speed", 0);
    }

    public void Attack()
    {
        isAttacking = true;
        navMeshAgent.destination = pawn.tempTarget.position;

        if (isAttacking)
        {
            if (Time.time > attackStartTime + waitTime)
            {
                pawn.HandleAttacking();
            }
        }
    }

    public void Chase()
    {
        navMeshAgent.destination = pawn.tempTarget.position;
        pawn.HandleEnemyMovement();
    }

    public void Search()
    {
        navMeshAgent.destination = pawn.lastKnownTransform.position;
        pawn.HandleEnemyMovement();
    }


    protected virtual void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        pawn = gameObject.GetComponent<Pawn>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        attackButtonObject = GameObject.Find("AttackButton");
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
