using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using UnityEngine.Experimental.XR;

public class Enemy : EnemyController
{
    

    //maxHealth value
    public float maxHealth;
    //initialHealth value
    [SerializeField] private float initialHealth;

    public float currentHealth;
    public float waitTIme;


    protected override void  Start()
    {
        currentHealth = initialHealth;
        this.gameObject.GetComponent<Pawn>().anim.SetFloat("Health", currentHealth);

        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        pawn = gameObject.GetComponent<Pawn>();

        for (int i = 1; i < 5; i++)
        {
            switch (i)
            {
                case 1:
                    patrolPoints.Add(GameObject.Find("PP_1").transform);
                    break;
                case 2:
                    patrolPoints.Add(GameObject.Find("PP_2").transform);
                    break;
                case 3:
                    patrolPoints.Add(GameObject.Find("PP_3").transform);
                    break;
                case 4:
                    patrolPoints.Add(GameObject.Find("PP_4").transform);
                    break;
            }
        }

        currentState = AI_STATES.Patrol;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];

    }

    protected override void Update()
    {
        switch (currentState)
        {
            case AI_STATES.Attack:
                Attack();


                break;
            case AI_STATES.Chase:
                Chase();


                break;
            case AI_STATES.Idle:
                Idle();

                if (seesPlayer && Vector3.Distance(transform.position, target.position) > 1f)
                {
                    ChangeStates(AI_STATES.Chase);
                }

                if (seesPlayer && Vector3.Distance(transform.position, target.position) < 1f)
                {
                    ChangeStates(AI_STATES.Attack);
                }

                if (Time.time > stateStartTime + waitTIme)
                {
                    ChangeStates(AI_STATES.Patrol);
                }

                break;
            case AI_STATES.Patrol:
                Patrol();

                break;
        }

        navMeshAgent.SetDestination(target.position);

    }


    
    //this property calculates the percent of health and returns it
    public float Percent
    {
        get
        {
            //new float variable percent equals the currentHealth divided by the maxHealth value
            float percent = currentHealth / maxHealth;

            //return the result
            return percent;
        }
    }

   
}


//public Weapon equippedWeapon;
//[SerializeField] private Transform rifleAttachmentPoint;
//[SerializeField] private Transform pistolAttachmentPoint;
//[SerializeField] private UnityEvent onEquip;
//public Animator playerAnimator;

//private Weapon weapon;

//public int weaponType;

//private bool isWeaponEquipped = false;

//public void EquipWeapon(Weapon equipWeapon, int type)
//{
//    if (isWeaponEquipped)
//    {
//        UnequipWeapon();
//    }

//    if (type == 1)
//    {
//        equippedWeapon = Instantiate(equipWeapon) as Weapon;
//        equippedWeapon.transform.SetParent(rifleAttachmentPoint);
//        equippedWeapon.transform.position = rifleAttachmentPoint.position;
//        equippedWeapon.transform.rotation = rifleAttachmentPoint.rotation;
//    }
//    else if (type == 2)
//    {
//        equippedWeapon = Instantiate(equipWeapon) as Weapon;
//        equippedWeapon.transform.SetParent(pistolAttachmentPoint);
//        equippedWeapon.transform.position = pistolAttachmentPoint.position;
//        equippedWeapon.transform.rotation = pistolAttachmentPoint.rotation;
//    }

//    isWeaponEquipped = true;
//    onEquip.Invoke();
//}

//public void UnequipWeapon()
//{
//    if (equippedWeapon)
//    {
//        Destroy(equippedWeapon.gameObject);
//        equippedWeapon = null;
//    }
//}

//void OnAnimatorIK()
//{
//    Debug.Log("Updating IK");

//    if (!equippedWeapon)
//    {
//        return;
//    }

//    if (equippedWeapon.RightIKTarget)
//    {
//        playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, equippedWeapon.RightIKTarget.position);
//        playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
//        playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, equippedWeapon.RightIKTarget.rotation);
//        playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
//    }
//    else
//    {
//        playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
//        playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
//    }

//    if (equippedWeapon.LeftIKTarget)
//    {
//        playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, equippedWeapon.LeftIKTarget.position);
//        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
//        playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, equippedWeapon.LeftIKTarget.rotation);
//        playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
//    }
//    else
//    {
//        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
//        playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
//    }
//}