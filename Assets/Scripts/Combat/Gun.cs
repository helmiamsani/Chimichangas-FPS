﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public int maxReserve = 80;
    public int currentReserve = 0;
    public int damage = 10;
    public Transform shotOrigin;
    public GameObject bulletPrefabs;
    public Text textUI;
    public AudioSource shootSound, recharge;

    private GameObject bulletClone;
    private bool isAttacking;
    private bool instantiateBullet;

    // Start is called before the first frame update
    void Start()
    {
        currentReserve = maxReserve;
        isAttacking = false;
        instantiateBullet = false;
    }

    private void FixedUpdate()
    {
        if (isAttacking)
        {
            currentReserve--;

            if (currentReserve <= 0)
            {
                currentReserve = 0;
                Destroy(bulletClone);
                shootSound.Stop();
            }
        }

        else if (!isAttacking)
        {
            currentReserve++;
            if (currentReserve >= maxReserve)
            {
                currentReserve = maxReserve;
                recharge.Stop();
            }
        }
        textUI.text = currentReserve.ToString();
    }

    public void Attack()
    {
        isAttacking = true;
        Camera cam = Camera.main;
        Vector3 direction = cam.transform.forward;

        if (instantiateBullet == false)
        {
            bulletClone = Instantiate(bulletPrefabs, shotOrigin.position, Quaternion.LookRotation(direction));
            instantiateBullet = true;
            shootSound.Play();
        }
    }

    public void NotAttacked()
    {
        isAttacking = false;
        instantiateBullet = false;
        Destroy(bulletClone);
        shootSound.Stop();
        recharge.Play();
    }
}
