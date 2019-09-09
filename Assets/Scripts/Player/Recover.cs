using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recover : MonoBehaviour
{
    public Health health; // health for storing health from Health script in player.
    [HideInInspector] public SmokeDamage[] smkDamages; // smoke damages for storing smoke damages that are found in each asteroid smoke. 

    private AsteroidManager asteroidManager; // asteroid Manager for storing asteroid manager from Game Manager.
    private GameObject[] asteroidSmokes; // asteroid Smokes for storing all asteroid smokes from Game Manager.
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>(); // Get the health script.
        asteroidManager = GameObject.Find("GameManager").GetComponent<AsteroidManager>(); // Get the asteroid Manager from Game Manager.
        asteroidSmokes = asteroidManager.asteroidSmokes; // Get asteroidSmokes from asteroid manager.
        smkDamages = new SmokeDamage[asteroidSmokes.Length]; // Get the amount of smoke damages.
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < asteroidSmokes.Length; i++)
        {
            if(asteroidSmokes[i] != null) // if each smoke in the array exists.
            {
                smkDamages[i] = asteroidSmokes[i].GetComponent<SmokeDamage>(); // Get the current smoke damage script from the current asteroid smoke

                if (!smkDamages[i].isPlayer) // if it is not player, increase health
                {
                    IncreaseHealth();
                }
            }
            else
            {
                asteroidSmokes[i] = null;
                smkDamages[i] = null;
                IncreaseHealth();
            }
        }
    }

    void IncreaseHealth()
    {
        health.currentHealth += Time.deltaTime; // Increase health.

        // Set the current health to max health if it the current is more than or equal to max health.
        if (health.currentHealth >= health.maxHealth)
        {
            health.currentHealth = health.maxHealth;
        }
    }
}
