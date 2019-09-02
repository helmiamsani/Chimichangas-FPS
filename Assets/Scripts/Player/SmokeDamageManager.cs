using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDamageManager : MonoBehaviour
{
    public Recover recover;

    [Header("Asteroid Smokes")]
    public GameObject asteroidSmoke;
    public GameObject[] asteroidSmokes;

    [Space]
    public bool playerInsideSmoke;

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
            StartCoroutine(whichAsteroid(asteroidSmoke));

            playerInsideSmoke = true;
        }

        if (!asteroidSmoke)
        {
            playerInsideSmoke = false;
        }

    }

    IEnumerator whichAsteroid(GameObject whichSmoke)
    {
        GameObject currentSmoke = whichSmoke;
        asteroidSmokes[0] = whichSmoke;

        yield return new WaitForEndOfFrame();
    }
}
