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

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = Mathf.Clamp01(currentHealth / maxHealth);
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
