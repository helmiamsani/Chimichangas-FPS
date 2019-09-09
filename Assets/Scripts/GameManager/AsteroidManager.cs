using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [Header("Asteroids")]
    public GameObject[] asteroidPrefabs;
    public GameObject[] asteroidSmokes;

    // Start is called before the first frame update
    void Awake()
    {
        asteroidSmokes = GameObject.FindGameObjectsWithTag("SmokeDamage");
        //asteroidSmokes[3].SetActive(false);
        //asteroidSmokes[4].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(asteroidPrefabs[0] == null && asteroidPrefabs[1] == null && asteroidPrefabs[2] == null)
        {
            Destroy(asteroidSmokes[asteroidSmokes.Length - 1]);
        }
    }
}
