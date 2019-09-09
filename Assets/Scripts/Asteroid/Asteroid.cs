using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int health = 30;
    public GameObject[] asteroidSmokes;
    [HideInInspector]
    public GameObject asteroidPrefab;

    private void Start()
    {
        asteroidPrefab = this.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            for (int i = 0; i < asteroidSmokes.Length; i++)
            {
                Destroy(asteroidSmokes[i]);
            }

            if (asteroidSmokes == null)
            {
                return;
            }
        }
    }
}
