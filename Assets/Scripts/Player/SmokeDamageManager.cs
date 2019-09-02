using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDamageManager : MonoBehaviour
{
    public Recover recover;

    [Header("Asteroid Smokes")]
    public GameObject asteroidSmoke;
    public GameObject[] asteroidSmokes;

    // Start is called before the first frame update
    void Start()
    {
        recover = GetComponent<Recover>();
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
