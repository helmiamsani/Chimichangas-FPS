using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDamage : MonoBehaviour
{
    public GameObject player;
    public Health plyrHealth;

    public bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        plyrHealth = player.GetComponent<Health>();
        isPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            plyrHealth.currentHealth -= Time.deltaTime; 
        }

        else if (!isPlayer)
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            isPlayer = true;
        }

        if (!player)
        {
            isPlayer = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player)
        {
            isPlayer = false;
        }
    }
}
