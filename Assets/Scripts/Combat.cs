using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Gun currentWeapon;

    public void HoldShoot()
    {
        if (currentWeapon)
        {
            currentWeapon.Attack();
        }
    }

    public void ShootOff()
    {
        if (currentWeapon)
        {
            currentWeapon.NotAttacked();
        }
    }
}
