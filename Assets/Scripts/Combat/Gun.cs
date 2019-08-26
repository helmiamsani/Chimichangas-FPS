using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public int maxReserve = 300, maxClip = 30;
    public float spread = 2f, recoil = 1f;
    public Transform shotOrigin;
    public GameObject bulletPrefabs;

    public int currentReserve = 0, currentClip = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Reload()
    {
        if(currentReserve > 0)
        {
            if(currentReserve >= maxClip)
            {
                int difference = maxClip - currentClip;
                currentReserve -= difference;
                currentClip = maxClip;
            }

            if(currentReserve < maxClip)
            {
                currentClip += currentReserve;
                currentReserve -= currentReserve;
            }
        }
    }

    public override void Attack()
    {
        currentClip--;

        Camera cam = Camera.main;
        Vector3 direction = cam.transform.forward;

        GameObject clone = Instantiate(bulletPrefabs, shotOrigin.position, Quaternion.identity);
        //Bullets bullet = clone.GetComponent<Bullets>();
        //bullet.Fire(direction);

        base.Attack();
    }
}
