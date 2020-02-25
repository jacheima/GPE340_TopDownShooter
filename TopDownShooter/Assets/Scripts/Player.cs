using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : WeaponsAgent
{
    private Weapon equippedWeapon;
    [SerializeField] private Transform attachmentPoint;

    [SerializeField] private float maxHealth;
    [SerializeField] private float initialHealth;

    private float currentHealth;

    private Weapon weapon;

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

    public void EquipWeapon(Weapon weapon)
    {
        equippedWeapon = Instantiate(weapon) as Weapon;
        equippedWeapon.transform.SetParent(attachmentPoint);
        equippedWeapon.transform.position = attachmentPoint.position;
        equippedWeapon.transform.rotation = attachmentPoint.rotation;
    }
}
