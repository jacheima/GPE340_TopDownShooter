using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class Player : WeaponsAgent
{
    private Weapon equippedWeapon;
    [SerializeField] private Transform rifleAttachmentPoint;
    [SerializeField] private Transform pistolAttachmentPoint;

    [SerializeField] private float maxHealth;
    [SerializeField] private float initialHealth;

    [SerializeField] private UnityEvent onEquip;

    private float currentHealth;

    private Weapon weapon;

    public int weaponType;

    private bool isWeaponEquipped = false;

    public enum WeaponAnimationType
    {
        None, Rifle, Pistol
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Heal(float amount)
    {

    }

    public void TakeDamage(float amount)
    {

    }

    public void EquipWeapon(Weapon equipWeapon, int type)
    {
        if (isWeaponEquipped)
        {
            UnequipWeapon();
        }

        if (type == 1)
        {
            equippedWeapon = Instantiate(equipWeapon) as Weapon;
            equippedWeapon.transform.SetParent(rifleAttachmentPoint);
            equippedWeapon.transform.position = rifleAttachmentPoint.position;
            equippedWeapon.transform.rotation = rifleAttachmentPoint.rotation;
        }
        else if (type == 2)
        {
            equippedWeapon = Instantiate(equipWeapon) as Weapon;
            equippedWeapon.transform.SetParent(pistolAttachmentPoint);
            equippedWeapon.transform.position = pistolAttachmentPoint.position;
            equippedWeapon.transform.rotation = pistolAttachmentPoint.rotation;
        }

        isWeaponEquipped = true;
        onEquip.Invoke();
    }

    public void UnequipWeapon()
    {
        if (equippedWeapon)
        {
            Destroy(equippedWeapon.gameObject);
            equippedWeapon = null;
        }
    }

    public float Percent
    {
        get
        {
            float percent = currentHealth / maxHealth;

            return percent;
        }
    }
}
