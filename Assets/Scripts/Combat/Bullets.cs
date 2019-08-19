using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int damage = 10;

    public float speed = 10f;

    private Rigidbody _rigid;

    // Start is called before the first frame update
    void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCollisionEnter(Collision col)
    {
        //Enemy enemy = col.collider.GetComponent<Enemy>();
        //if (enemy)
        //{
        //}
        Destroy(this.gameObject);
    }

    public void Fire(Vector3 direction)
    {
        _rigid.AddForce(direction * speed, ForceMode.Impulse);
    }
}
