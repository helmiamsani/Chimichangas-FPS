using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRotation2 : MonoBehaviour
{
    public float minPitch = -80f, maxPitch = 80f;
    public float rotSpeed = 0.8f;

    public Joystick joystick;
    private Vector2 euler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(joystick.Horizontal, joystick.Vertical, 0);

        euler.y += direction.x * rotSpeed * Time.deltaTime;
        euler.x -= direction.y * rotSpeed * Time.deltaTime;

        euler.x = Mathf.Clamp(euler.x, minPitch, maxPitch);

        transform.parent.localEulerAngles = new Vector3(0, euler.y, 0);
        transform.localEulerAngles = new Vector3(euler.x, 0, 0);
    }
}
