using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//This is the base class for the weapon types
public class Weapon : MonoBehaviour
{
    //amount of damage
    [SerializeField] private float damageAmount;
    //the attack speed of the weapon
    [SerializeField] private float attackSpeed;

    //event called onAttackStart
    [SerializeField] protected UnityEvent onStartAttack;
    //event called on the end of an attack
    [SerializeField] protected UnityEvent onEndAttack;

    //reference to the player
    [SerializeField] private Player player;

    //the weapon type
    public int weaponType;

    [Header("IK Settings")]
    //reference to the left Ik target
    public Transform LeftIKTarget;
    //reference to the right IK target
    public Transform RightIKTarget;

    [Header("Bullet Settings")]
    //reference to the bulletPrefab
    [SerializeField] private GameObject bulletPrefab;
    //reference to the bullet spawn transform
    [SerializeField] private Transform bulletSpawn;
    //the speed of the buller
    [SerializeField] private float bulletSpeed;
    //the spread of the bullet
    [SerializeField] private float spread;

    //has the trigger been pulled (has the attack started?)
    public bool isTriggerPulled;
    


    protected virtual void Start()
    {
        //set the player 
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    protected virtual void Update()
    {
        //if the trigger has been pulled
        if (isTriggerPulled)
        {
            //instantiate the bullet at the bulletSpawn
            Bullet bullet = Instantiate(bulletPrefab.GetComponent<Bullet>(), bulletSpawn.transform.position, bulletPrefab.transform.rotation * Quaternion.Euler(Random.onUnitSphere * spread)) as Bullet;
            //set the damage amount to the bullet as defined in the weapon 
            bullet.damage = damageAmount;
            //add force to the rigidbody to propell the bullet forward
            bullet.rb.AddRelativeForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);

            if(weaponType == 1)
            {
                Game_Manager.instance.machineGunCurrentMag--;
            }
            if(weaponType == 2)
            {
                Game_Manager.instance.pistolCurrentMag--;
            }
            //set isTriggerPulled to false
            isTriggerPulled = false;
        }
    }

    protected virtual void FixedUpdate()
    {
        //set the bullet layer to the player layers
        bulletPrefab.gameObject.layer = player.gameObject.layer;
    }
    protected virtual void OnStartAttack()
    {

    }

    protected virtual void OnEndAttack()
    {

    }

    

}
