using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSmokes2 : MonoBehaviour
{
    public SmokeDamageManager smkDmgManager;
    public SmokeDamage smkDamage;

    // Start is called before the first frame update
    void Start()
    {
        smkDamage = GetComponent<SmokeDamage>();
        smkDmgManager = GameObject.FindGameObjectWithTag("Player").GetComponent<SmokeDamageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(smkDmgManager.asteroidSmokes[1] == null)
        {
            smkDamage.damage = 0;
        }
    }
}
