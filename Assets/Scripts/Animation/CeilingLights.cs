using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingLights : MonoBehaviour
{
    public Animator lightAnimator;
    public float lightDelay;


    private float time;
    private float firstDelay = 0f;
    private int chance;
    // Start is called before the first frame update
    void Start()
    {
        lightAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; // Time is counting

        if(time > firstDelay) // if time is more than the first delay
        {
            firstDelay = time + lightDelay; 

            chance = Random.Range(0, 2);
            if(chance == 0)
            {
                lightAnimator.SetBool("isTwiceOn", true);
            }
            else
            {
                lightAnimator.SetBool("isTwiceOn", false);
            }
            
        }
    }
}
