using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

//the player script that keeps track of health and such
public class Player : WeaponsAgent
{
    //reference to the current equipped weapon
    public Weapon equippedWeapon;
    
    //references to the spawn locations for the weapons
    [SerializeField] private Transform rifleAttachmentPoint;
    [SerializeField] private Transform pistolAttachmentPoint;
    [SerializeField] private Transform shotgunAttachmentPoint;

    public int liveCount;

    //the maximum health value
    public float maxHealth;

    //the initial health value
    public float initialHealth = 100;

    //an event that is called when the player equips a weapon
    [SerializeField] private UnityEvent onEquip;

    //the current health of the player
    public float currentHealth;

    //reference to the players animator
    public Animator playerAnimator;

    //variable that hold the weapon type for the animation layer
    public int weaponType;

    //boolean to check if an weapon is equipped
    private bool isWeaponEquipped = false;

    // Start is called before the first frame update
    void Start()
    {
        //set the animator to the animator on the player gameobject
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Health", initialHealth);

        //set the current health to the initial health
        currentHealth = initialHealth;
    }

    //method adds health to the players current health
    public void Heal(float amount)
    {
        //add the heal amount to the current health
        currentHealth += amount;

    }

    //method that subtracts damage from the players current health
    public void TakeDamage(float amount)
    {
        //subtract the damage amount from the current health
        currentHealth -= amount;
    }

    //method handles equipping weapons
    public void EquipWeapon(Weapon equipWeapon, int type)
    {
        //if weapon is currently equipped
        if (isWeaponEquipped)
        {
            //call the un-equip the weapon
            UnequipWeapon();
        }

        //if the weapon type is 1 (rifle)
        if (type == 1)
        {
            //instantiate the weapon in the correct weapon attachment point
            equippedWeapon = Instantiate(equipWeapon) as Weapon;
            equippedWeapon.transform.SetParent(rifleAttachmentPoint);
            
            //change the weapons position and rotation to the weapon
            equippedWeapon.transform.position = rifleAttachmentPoint.position;
            equippedWeapon.transform.rotation = rifleAttachmentPoint.rotation;

            //set the gameobject to the same layer as the player layer
            equippedWeapon.gameObject.layer = gameObject.layer;

            Game_Manager.instance.machineGunEquipped = true;
            Game_Manager.instance.pistolEquiped = false;
        }
        //if the weapon type is 2 (pistol)
        else if (type == 2)
        {
            //instantiate the weapon in the correct weapon attachment point
            equippedWeapon = Instantiate(equipWeapon) as Weapon;
            equippedWeapon.transform.SetParent(pistolAttachmentPoint);

            //change the weapons position and rotation to the attachment point
            equippedWeapon.transform.position = pistolAttachmentPoint.position;
            equippedWeapon.transform.rotation = pistolAttachmentPoint.rotation;

            //set the gameobject to the same layer as the player layer
            equippedWeapon.gameObject.layer = gameObject.layer;

            Game_Manager.instance.machineGunEquipped = false;
            Game_Manager.instance.pistolEquiped = true;

        }
        //if the weapon type is 3 (shotgun)
        else if (type == 3)
        {
            //instantiate the weapon in the correct weapon attachment point
            equippedWeapon = Instantiate(equipWeapon) as Weapon;
            equippedWeapon.transform.SetParent(shotgunAttachmentPoint);

            //change the weapons position and rotation to the attachment point
            equippedWeapon.transform.position = shotgunAttachmentPoint.position;
            equippedWeapon.transform.rotation = shotgunAttachmentPoint.rotation;

            //set the gameobject to the same layer as the player layer
            equippedWeapon.gameObject.layer = gameObject.layer;
        }

        //set the isWeaponEquipped boolean to true
        isWeaponEquipped = true;

        //invoke the event to set the correct animations
        onEquip.Invoke();
    }

    //this method is used to un-equip the weapon
    public void UnequipWeapon()
    {
        //if there is a weapon equipped
        if (equippedWeapon)
        {
            //destroy the equipped weapon
            Destroy(equippedWeapon.gameObject);

            //set the equipped weapon to null
            equippedWeapon = null;

            Game_Manager.instance.machineGunEquipped = false;
            Game_Manager.instance.pistolEquiped = false;
            isWeaponEquipped = false;
        }
    }

    //property to calculate the percent of health
    public float Percent
    {
        get
        {
            //divide the current health by the maxHealth to get the percent of health
            float percent = currentHealth / maxHealth;

            //return the percent
            return percent;
        }
    }

    //this method gets called when the Animator does an IK pass
    void OnAnimatorIK()
    {
        //is the equipped weapon is null
        if (!equippedWeapon)
        {
            //stop
            return;
        }

        //if the right IK target is not null
        if (equippedWeapon.RightIKTarget)
        {
            //set the IK position to the right IK target
            playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, equippedWeapon.RightIKTarget.position);
            //set the IK position weight to 1f
            playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            //set the IK rotation to the right IK target
            playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, equippedWeapon.RightIKTarget.rotation);
            //set the IK rotation weight to 1f
            playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
        }
        //if the right IK target is not set
        else
        {
            //set the position and rotation weight to 0 so that it is un-effected
            playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
        }

        //if the left IK target is not null
        if (equippedWeapon.LeftIKTarget)
        {
            //set the IK position to the right IK target
            playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, equippedWeapon.LeftIKTarget.position);
            //set the IK position weight to 1f
            playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            //set the IK rotation to the right IK target
            playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, equippedWeapon.LeftIKTarget.rotation);
            //set the IK rotation weight to 1f
            playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
        }
        //if the left IK target is not set
        else
        {
            //set the position and rotation weight to 0 so that it is un-effected
            playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
        }
    }
}
