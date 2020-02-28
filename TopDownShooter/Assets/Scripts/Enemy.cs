using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : EnemyController
{
    

    //maxHealth value
    public float maxHealth;
    //initialHealth value
    [SerializeField] private float initialHealth;

    public float currentHealth;

    //this function adds the heal amount to the current health
    public void Heal(float amount)
    {
        //add the heal amount to the currentHealth
        currentHealth += amount;
    }

    //this function adds the damage amount to the currentHealth
    public void TakeDamage(float amount)
    {
        //subtract the damage amount from the currentHealth
        currentHealth -= amount;
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