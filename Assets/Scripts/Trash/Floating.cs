using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float floatSpeed = .1f;
    public float addForce = 10f;

    private float time;
    private float initialSpeed;
    private float firstAddForce = 0.5f;
    private float secondAddforce;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        initialSpeed = floatSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        Vector3 direction = this.transform.up;
        rigid.AddForce(direction * floatSpeed);

        if (time > firstAddForce)
        {
            firstAddForce = time + addForce;
            floatSpeed = 0;
            return;
        }

    }
}
