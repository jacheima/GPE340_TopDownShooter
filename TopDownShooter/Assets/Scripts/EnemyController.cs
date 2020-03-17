using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform target;

    [SerializeField] private Pawn pawn;

    protected virtual void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        pawn = gameObject.GetComponent<Pawn>();
        target = GameObject.Find("Player").GetComponent<Transform>();
    }
    public void Update()
    {
        Debug.Log(navMeshAgent.destination);
        navMeshAgent.SetDestination(target.position);
        pawn.HandleEnemyMovement();
    }

    protected void OnAnimatorMove()
    {
        navMeshAgent.velocity = pawn.anim.velocity;
    }
}
