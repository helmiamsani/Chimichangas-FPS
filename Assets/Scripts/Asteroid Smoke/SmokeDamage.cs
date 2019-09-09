using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmokeDamage : MonoBehaviour
{
    public GameObject player;
    public Health plyrHealth;
    public float damage;
    public SmokeDamageManager smkDmgMngr;
    public bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        plyrHealth = player.GetComponent<Health>();
        smkDmgMngr = GameObject.Find("GameManager").GetComponent<SmokeDamageManager>();
        isPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            plyrHealth.currentHealth -= Time.deltaTime * damage;
            smkDmgMngr.asteroidSmoke = gameObject;

            if (plyrHealth.currentHealth <= 0)
            {
                plyrHealth.dead = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            isPlayer = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (player)
        {
            isPlayer = false;
            smkDmgMngr.asteroidSmoke = null;
        }
    }
}
