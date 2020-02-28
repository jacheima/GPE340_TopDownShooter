using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//This class controls the UI
public class UI : MonoBehaviour
{
    //reference to the player component
    public Player health;
    //reference to the healthFill image
    [SerializeField] private Image healthFill;

    private void Awake()
    {
        //find the player gameobject and set the it to the variable
        health = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        //set the fillAnount equal to the health percent
        healthFill.fillAmount = health.Percent;
    }
}
