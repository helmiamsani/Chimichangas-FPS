using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        player = GameObject.Find("Player");
        plyrHealth = player.GetComponent<Health>();
        smkDmgMngr = player.GetComponent<SmokeDamageManager>();
        isPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            plyrHealth.currentHealth -= Time.deltaTime * damage;
            smkDmgMngr.asteroidSmoke = gameObject;
            Debug.Log("Should be Updated Right");
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
