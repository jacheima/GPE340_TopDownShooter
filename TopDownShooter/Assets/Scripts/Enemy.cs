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
    

    public float attackDistance;
    


    protected override void  Start()
    {
        currentHealth = initialHealth;
        this.gameObject.GetComponent<Pawn>().anim.SetFloat("Health", currentHealth);

        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        pawn = gameObject.GetComponent<Pawn>();

        target = GameObject.Find("Player").transform;

        navMeshAgent.SetDestination(target.position);
        currentState = AI_STATES.Move;
    }

    protected override void Update()
    {
        switch (currentState)
        {
            case AI_STATES.Attack:
                Attack();

                if (Vector3.Distance(transform.position, target.position) < attackDistance)
                {
                    ChangeStates(AI_STATES.Move);
                }

                break;
            case AI_STATES.Move:
                Move();

                if (Vector3.Distance(transform.position, target.position) <= attackDistance)
                {
                    ChangeStates(AI_STATES.Attack);
                }

                break;
        }


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