using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Gun currentWeapon;
    private RayForShooting ray;
    private Player player;
    private PlatformManager platform;

    void Start()
    {
        platform = GameObject.Find("GameManager").GetComponent<PlatformManager>();   
    }

    void Update()
    {
        if (platform.PC)
        {
            bool inputHoldLeftKey = Input.GetMouseButtonDown(0);
            bool inputReleaseLeftKey = Input.GetMouseButtonUp(0);
            if (inputHoldLeftKey)
            {
                HoldShoot();
            }

            if (inputReleaseLeftKey)
            {
                ShootOff();
            }
        }
    }

    public void HoldShoot()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (player.canMove)
        {
            currentWeapon.Attack();
            ray = Camera.main.GetComponent<RayForShooting>();
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
