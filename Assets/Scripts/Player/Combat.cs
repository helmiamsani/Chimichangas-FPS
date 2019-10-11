using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Gun currentWeapon; // stores the current weapon is carrying.
    private RayForShooting ray; // stores RayForShooting.
    private Player player; // Stores Player.
    private PlatformManager platform; // Stores PlatformManager.

    void Start()
    {
        platform = GameObject.Find("GameManager").GetComponent<PlatformManager>(); // Get PlatformManager from GameManager.
    }

    void Update()
    {
        if (platform.PC) // if it is on PC
        {
            bool inputHoldLeftKey = Input.GetMouseButtonDown(0); // Stores left mouse key.
            bool inputReleaseLeftKey = Input.GetMouseButtonUp(0); // Stores right mouse key.
            if (inputHoldLeftKey) 
            {
                HoldShoot(); // Shoot.
            }

            if (inputReleaseLeftKey)
            {
                ShootOff(); // Don't shoot.
            }
        }
    }

    public void HoldShoot()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); // Get Player.

        if (player.canMove) // If player can move
        {
            currentWeapon.Attack(); // Launch bullet.
            ray = Camera.main.GetComponent<RayForShooting>(); // 
            ray.holdShoot = true;
        }
    }

    public void ShootOff()
    {
        if (currentWeapon)
        {
            currentWeapon.NotAttacked();
            ray = Camera.main.GetComponent<RayForShooting>();
            ray.holdShoot = false;
        }
    }
}
