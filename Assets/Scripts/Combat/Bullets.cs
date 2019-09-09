using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int damage = 10;
    public Transform shootOrigin;

    
    //public GameObject[] asteroidPrefabs;

    // Update is called once per frame
    void Update()
    {
        //asteroidPrefabs = GameObject.FindGameObjectsWithTag("Asteroid");

        shootOrigin = GameObject.FindGameObjectWithTag("ShootOrigin").GetComponent<Transform>();
        transform.position = shootOrigin.position;        
    }
}
