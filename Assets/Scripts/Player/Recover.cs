using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour
{
    public Health health;
    public GameObject[] asteroidSmokes;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        asteroidSmokes = GameObject.FindGameObjectsWithTag("SmokeDamage");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject asteroidSmoke in asteroidSmokes)
        {
            SmokeDamage smkDamage = asteroidSmoke.GetComponent<SmokeDamage>();

            if (!smkDamage.isPlayer)
            {
                health.currentHealth += Time.deltaTime;

                if (health.currentHealth >= health.maxHealth)
                {
                    health.currentHealth = health.maxHealth;
                }
            }
        }
    }
}
