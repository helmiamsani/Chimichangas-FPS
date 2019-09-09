using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 10;
    //public float attackRange; 
    public float attackRate;
    public bool canAttack = false;

    private float _attackTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        _attackTimer += Time.deltaTime;
        if(_attackTimer >= 1f / attackRate)
        {
            canAttack = true;
        }
    }

    public virtual void Attack()
    {
        _attackTimer = 0f;
        canAttack = false;
    }
}
