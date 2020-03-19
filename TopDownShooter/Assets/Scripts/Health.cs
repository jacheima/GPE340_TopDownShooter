using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    float waitTime = 5f;
    float stateStartTime;

    private bool isDead;

    void Start()
    {
        isDead = false;
    }

    void Update()
    {
        if (Time.time > stateStartTime + waitTime && isDead)
        {
            Kill(this.gameObject);
        }
    }

    //this method heals the enemy or player the amount designated by the health pack
    public void Heal(float amount)
    {
        //if it is the player
        if (gameObject.GetComponent<Player>())
        {
            //save the player component to a variable for accessibility
            Player player = gameObject.GetComponent<Player>();

            //if the players health will be equal to maxHealth or exceed maxHealth
            if (player.currentHealth + amount >= player.maxHealth)
            {
                //call FullHeal function to instantly set the player to maxHealth
                FullHeal(player, null);
            }
            //otherwise
            else
            {
                //heal the player the amount designated by the health pack
                player.currentHealth += amount;
            }


        }
        //if it was an enemy to get the health pack
        else if (gameObject.GetComponent<Enemy>())
        {
            //save the enemy component to a variable for accessibility
            Enemy enemy = gameObject.GetComponent<Enemy>();

            //if the enemy health will be equal to maxHealth or exceed maxHealth
            if (enemy.currentHealth + amount >= enemy.maxHealth)
            {
                //call FullHeal function to instantly set the enemy to maxHealth
                FullHeal(null, enemy);
            }
            //otherwise, 
            else
            {
                //heal the enemy the amount designated by the health pack
                enemy.currentHealth += amount;
            }
        }
    }

    //This method adds damage to the enemy or player
    public void TakeDamage(float damage, GameObject pawn)
    {
        //if the player took damage
        if (pawn.GetComponent<Player>())
        {
            //save the player component to a variable for accessibility
            Player player = pawn.GetComponent<Player>();

            //if the players health would be less than or equal to 0 after taking the damage
            if (player.currentHealth - damage <= 0)
            {
                //call the kill function which would instantly kill the player
                Kill(pawn);
            }
            //otherwise,
            else
            {
                //add the damage to the player
                player.currentHealth -= damage;
            }


        }
        //if the enemy took damage
        else if (pawn.GetComponent<Enemy>())
        {
            //save the enemy component to a variable for accessibility
            Enemy enemy = pawn.GetComponent<Enemy>();

            //if the enemy health would be less than or equal to 0 after taking damage
            if (enemy.currentHealth - damage <= 0)
            {
                pawn.GetComponent<Pawn>().anim.SetFloat("Health", 0);
                //pawn.GetComponent<NavMeshAgent>().destination = null;

                isDead = true;
                float stateStartTime = Time.time;
                

            }
            //otherwise, 
            else
            {
                //add the damage to the enemy
                enemy.currentHealth -= damage;
            }
        }
    }

    //this function kills the gameobject passed into the function
    public void Kill(GameObject kill)
    {
        //destroy the gameobject passed to it
        Destroy(kill);

        //Debug.Log(kill.gameObject.name + " was killed");

        //if the person killed was an enemy
        if (kill.gameObject.GetComponent<Enemy>())
        {
            //set the bool in the game manager to false, so another enemy will spawn
            Game_Manager.instance.isTimerSet = false;
        }

    }

    //this method instantly sets the player or enemy health to maxHealth when called
    void FullHeal(Player player, Enemy enemy)
    {
        //if player is not null and enemy is null
        if (player && !enemy)
        {
            //set the players current health equal to the maxHealth value
            player.currentHealth = player.maxHealth;
        }

        //if the player is null but the enemy is not null
        if (!player && enemy)
        {
            //set the enemy current health equal to the maxHealth value
            enemy.currentHealth = enemy.maxHealth;
        }
    }
}
