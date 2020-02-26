using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private Player player;
    public enum WeaponAnimationType
    {
        None, Rifle, Pistol
    }

    private WeaponAnimationType animationType = WeaponAnimationType.None;

    private Animator playerAnimator;

    void Awake()
    {

    }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerAnimator = player.GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void ChangeAnimation()
    {
        switch (player.weaponType)
        {
            case 0:
                playerAnimator.SetInteger("Weapon Type", 0);
                break;
            case 1:
                playerAnimator.SetInteger("Weapon Type", 1);
                break;
            case 2:
                playerAnimator.SetInteger("Weapon Type", 2);
                break;
        }
    }

}
