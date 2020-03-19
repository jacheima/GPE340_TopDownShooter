using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pawn : MonoBehaviour
{
    //the speed the player moves at
    [SerializeField] private float speed;
    //reference to the animator
    public Animator anim;
    public LayerMask layer;

    //reference to the player component
    private Player player;

    private Enemy enemy;

    [Header("FOV")] public float viewRadius;

    private void Awake()
    {
        //set the animator by getting the component
        anim = GetComponent<Animator>();
        //set the player component by getting the player component
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (this.gameObject.GetComponent<Enemy>())
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, viewRadius, layer);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                Transform target = hitColliders[i].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (hitColliders[i].gameObject.GetComponent<Player>())
                {
                    if (Vector3.Angle(transform.forward, directionToTarget) < viewRadius / 2)
                    {
                        float distanceToTarget = Vector3.Distance(transform.position, target.position);

                        if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, layer))
                        {
                            if (distanceToTarget <= viewRadius)
                            {
                                Enemy enemy = this.gameObject.GetComponent<Enemy>();

                                enemy.seesPlayer = true;
                                enemy.navMeshAgent.destination = target.position;

                            }
                        }
                    }
                }
            }
        }
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

    



}
