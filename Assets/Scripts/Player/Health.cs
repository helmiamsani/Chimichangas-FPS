using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Slider healthSlider;
    public Image healthFill;

    public bool dead;

    private void Start()
    {
        currentHealth = maxHealth;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = Mathf.Clamp01(currentHealth / maxHealth);
        if (dead)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.canMove = false;
            currentHealth = 0;
        }
    }

    void HealthManager()
    {
        if(currentHealth <= 0 && healthFill.enabled)
        {
            healthFill.enabled = false;
        }
        else if(!healthFill.enabled && currentHealth > 0)
        {
            healthFill.enabled = enabled;
        }
    }
}
