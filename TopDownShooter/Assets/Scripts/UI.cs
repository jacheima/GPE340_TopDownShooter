using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Health health;
    [SerializeField] private Image healthFill;

    private void Awake()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
    }

    private void Update()
    {
        healthFill.fillAmount = health.Percent;
    }
}
