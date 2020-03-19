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

    [Header("FOV")]
    public float viewRadius;
    public float viewAngle;
    public Transform lastKnownTransform;
    public float distanceToTarget;
    public Transform target;
    public Transform tempTarget;
    public Mesh newMesh;

    private void Awake()
    {
        //set the animator by getting the component
        anim = GetComponent<Animator>();
        //set the player component by getting the player component
        player = GetComponent<Player>();
    }

    void Start()
    {
        tempTarget = new GameObject("FollowTarget").transform;
    }

    void Update()
    {
        //if this game object has the enemy component (if this is an enemy)
        if (this.gameObject.GetComponent<Enemy>())
        {

            //set the enemy by getting the enemy component on this gameobject
            Enemy enemyPawn = this.gameObject.GetComponent<Enemy>();

            //create an array populated with every game object in the view radius
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, viewRadius);

            //for each hit in the hitColliders array
            for (int i = 0; i < hitColliders.Length; i++)
            {
                
                //if the current hitCollider has the player component (if the current hit is the player)
                if (hitColliders[i].gameObject.GetComponent<Player>())
                {
                    //set the target to the current transform of the current index in the hitCollider array
                    target = hitColliders[i].transform;
                    tempTarget.transform.position = target.position;
                    

                    //calculate the direction(vector) to the target
                    Vector3 directionToTarget = (target.position - transform.position).normalized;

                    //calculate the distance to the target
                    distanceToTarget = Vector3.Distance(transform.position, target.position);

                    //if the angle to the player is less than half the view angle
                    if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
                    {
                        Debug.Log("SeesPlayer = True");

                        if (distanceToTarget <= viewRadius)
                        {
                            enemyPawn.seesPlayer = true;
                            lastKnownTransform = tempTarget.transform;
                        }
                        else
                        {
                            enemyPawn.seesPlayer = false;
                        }
                    }
                    else
                    {
                        enemyPawn.seesPlayer = false;
                    }
                }
            }
        }
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





}
