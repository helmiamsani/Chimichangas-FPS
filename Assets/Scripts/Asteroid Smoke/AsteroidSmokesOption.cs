using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSmokesOption : MonoBehaviour
{
    [Header("What smoke it is?")]
    public bool firstSmoke; // 
    public bool secondSmoke;

    [Header("References")]
    public SmokeDamageManager smkDmgManager;
    public SmokeDamage smkDamage;



    private float initialDamage;

    // Start is called before the first frame update
    void Start()
    {
        smkDamage = GetComponent<SmokeDamage>();
        smkDmgManager = GameObject.Find("GameManager").GetComponent<SmokeDamageManager>();
        initialDamage = smkDamage.damage;
    }

    // Update is called once per frame
    void Update()
    {
        if(firstSmoke == true)
        {
            if(smkDmgManager.asteroidSmokes[0] == null)
            {
                smkDamage.damage = 0;
            }
            else
            {
                smkDamage.damage = initialDamage;
            }
        }

        if(secondSmoke == true)
        {
            if (smkDmgManager.asteroidSmokes[1] == null)
            {
                smkDamage.damage = 0;
            }
            else
            {
                smkDamage.damage = initialDamage;
            }
        }
    }
}
