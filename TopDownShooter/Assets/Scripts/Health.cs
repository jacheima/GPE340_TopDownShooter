using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float intialHealth;

    [SerializeField] private UnityEvent onHeal;
    [SerializeField] private UnityEvent onDamage;
    [SerializeField] private UnityEvent onDie;

    private float currentHealth;


    public void Heal(float amount)
    {
        currentHealth += amount;
    }

    void TakeDamage(float damage)
    {

    }

    void Kill()
    {

    }

    void FullHeal()
    {

    }

    public float Percent
    {
        get
        {
            float percent = currentHealth / maxHealth;

            return percent;
        }
    }
}
