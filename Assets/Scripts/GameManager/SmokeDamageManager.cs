using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDamageManager : MonoBehaviour
{
    [Header("Telling Where the Player is??")]
    public GameObject asteroidSmoke; // in which smokes does the player in
    //[HideInInspector]
    public GameObject[] asteroidSmokes;

    [Header("Reference")]
    public Recover recover;

    // Start is called before the first frame update
    void Start()
    {
        recover = GameObject.FindGameObjectWithTag("Player").GetComponent<Recover>();
        asteroidSmokes = new GameObject[2];       
    }

    // Update is called once per frame
    void Update()
    {
        if (asteroidSmoke)
        {
            // When inside asteroid smokes collider
            if (asteroidSmoke.ToString() == "Asteroid Smokes (UnityEngine.GameObject)" || asteroidSmoke.ToString() == "Asteroid Smokes 3 (UnityEngine.GameObject)")
            {
                asteroidSmokes[0] = asteroidSmoke;

                if(asteroidSmokes[1] != null)
                {
                    asteroidSmokes[1] = null;
                }
            }            

            // When inside asteroid smokes 2 collider
            else if (asteroidSmoke.ToString() == "Asteroid Smokes 2 (UnityEngine.GameObject)" || asteroidSmoke.ToString() == "Asteroid Smokes 4 (UnityEngine.GameObject)")
            {
                asteroidSmokes[1] = asteroidSmoke;
                asteroidSmokes[0] = null;
            }
        }

        if (!asteroidSmoke)
        {
            asteroidSmokes[0] = null;
            asteroidSmokes[1] = null;
        }

    }
}
