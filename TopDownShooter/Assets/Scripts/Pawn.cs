using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pawn : MonoBehaviour
{
    //the speed the player moves at
    [SerializeField] private float speed;
    //reference to the animator
    public Animator anim;

    //reference to the player component
    public Player player;
    private Enemy enemy;

    public bool isDeathAnimDone;

    private void Awake()
    {
        //set the animator by getting the component
        anim = GetComponent<Animator>();
        //set the player component by getting the player component
        player = GetComponent<Player>();
    }

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public Vector3 AngleToTarget(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    //this method handles the movement, by setting the variables in the animator
    public void HandleMovement(Vector3 movement)
    {
        //set the parameters that controls the animations movement
        anim.SetFloat("Horizontal", movement.x * speed);
        anim.SetFloat("Vertical", movement.z * speed);
    }

    public void HandleEnemyMovement()
    {
        anim.SetFloat("Speed", speed);
    }

    //this method handles shooting, by setting the isTriggerPulled to true
    public void HandleShooting()
    {
        //if the player has an weapon equipped
        if (player.equippedWeapon)
        {
            //set isTriggerPulled equal to true
            player.equippedWeapon.isTriggerPulled = true;
        }
    }

    public void HandleAttacking()
    {
        Enemy enemyPawn = this.gameObject.GetComponent<Enemy>();

        enemyPawn.attackStartTime = Time.time;
        anim.SetBool("isAttacking", true);
    }

    public void EndAttack()
    {
        Debug.Log("Called EndAttack");

        Enemy enemyPawn = this.gameObject.GetComponent<Enemy>();

        anim.SetBool("isAttacking", false);
        enemyPawn.isAttacking = false;
    }

    public void EndOfDeath()
    {
        isDeathAnimDone = true;
        Destroy(this.gameObject, 2f);
    }





}
