using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Weapon currentWeapon;

    // Update is called once per frame
    void Update()
    {
    }

    public void Shoot()
    {
        if (currentWeapon && currentWeapon.canAttack)
        {
            currentWeapon.Attack();
        }
    }
}
