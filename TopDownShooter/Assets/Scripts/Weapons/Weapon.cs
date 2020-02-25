using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damageAmount;
    [SerializeField] private float attackSpeed;

    [SerializeField] protected UnityEvent onStartAttack;
    [SerializeField] protected UnityEvent onEndAttack;

    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {
        
    }
    protected virtual void OnStartAttack()
    {

    }

    protected virtual void OnEndAttack()
    {

    }
}
