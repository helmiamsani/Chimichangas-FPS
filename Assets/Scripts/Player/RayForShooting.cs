using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayForShooting : MonoBehaviour
{
    public GameObject asteroidPrefab;
    [HideInInspector] public bool holdShoot;

    private Asteroid asteroid;
    private GameObject[] asteroidSmokes;
    private Gun blaster;
    private void Start()
    {
        blaster = GameObject.Find("Blaster Edited").GetComponent<Gun>();                
    }

    // Update is called once per frame
    void Update()
    {
        if (holdShoot)
        {
            Ray interact;
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            RaycastHit damage;

            if (Physics.Raycast(interact, out damage, 10))
            {
                if (damage.collider.CompareTag("Asteroid"))
                {
                    asteroidPrefab = GameObject.FindGameObjectWithTag("Asteroid");
                    if (asteroidPrefab != null)
                    {
                        asteroid = asteroidPrefab.GetComponent<Asteroid>();
                        asteroid.health -= blaster.damage;
                    }
                }

                if (damage.collider.CompareTag("Asteroid1"))
                {
                    asteroidPrefab = GameObject.FindGameObjectWithTag("Asteroid1");

                    if (asteroidPrefab != null)
                    {
                        asteroid = asteroidPrefab.GetComponent<Asteroid>();
                        asteroid.health -= blaster.damage;
                    }
                }

                if (damage.collider.CompareTag("Asteroid2"))
                {
                    asteroidPrefab = GameObject.FindGameObjectWithTag("Asteroid2");

                    if (asteroidPrefab != null)
                    {
                        asteroid = asteroidPrefab.GetComponent<Asteroid>();
                        asteroid.health -= blaster.damage;
                    }
                }
            }
        }
    }
}
