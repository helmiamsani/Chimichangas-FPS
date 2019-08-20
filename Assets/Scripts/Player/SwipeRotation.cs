using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRotation : MonoBehaviour
{
    // >>> MANNY PUNYA <<<
    private Touch initialTouch = new Touch();

    //public Camera cam;
    //public Player player;
    public float minPitch = -80f, maxPitch = 80f;
    public float rotSpeed = 0.8f;

    private float scrW = Screen.width / 16;
    private float scrH = Screen.height / 9;
    private Vector2 euler;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        euler = transform.eulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Right Part for Rotation
        Rect rBounds = new Rect(8f * scrW,0, Screen.width, Screen.height);
        // Left Part for Rotation
        Rect lBounds = new Rect(0, 0, Screen.width/2, Screen.height);

        if (Input.touchCount > 0)
        {
            Touch rTouch = Input.GetTouch(0);

            if (rBounds.Contains(rTouch.position))
            {
                Rotate(rTouch);
            }
        }

        if (Input.touchCount > 1)
        {
            Touch lTouch = Input.GetTouch(1);

            if (rBounds.Contains(rBounds.position))
            {
                Rotate(lTouch);
            }
        }
    }

    public void Rotate(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            initialTouch = touch;
        }

        if (touch.phase == TouchPhase.Moved)
        {
            float deltaX = touch.position.x - initialTouch.position.x;
            float deltaY = touch.position.y - initialTouch.position.y;
            euler.y += deltaX * rotSpeed * Time.deltaTime;
            euler.x -= deltaY * rotSpeed * Time.deltaTime;

            euler.x = Mathf.Clamp(euler.x, minPitch, maxPitch);

            transform.parent.localEulerAngles = new Vector3(0, euler.y, 0);
            transform.localEulerAngles = new Vector3(euler.x, 0, 0);
        }

        if (touch.phase == TouchPhase.Ended)
        {
            initialTouch = new Touch();
        }
    }

    #region Trash
    //foreach (Touch touch in Input.touches)
    //{
    //    if (touch.phase == TouchPhase.Began)
    //    {
    //        initialTouch = touch;
    //    }

    //    else if (touch.phase == TouchPhase.Moved)
    //    {
    //        //Rotate(initialTouch, touch, speed, euler);]
    //        float deltaX = touch.position.x - initialTouch.position.x;
    //        float deltaY = touch.position.y - initialTouch.position.y;
    //        euler.y += deltaX * rotSpeed * Time.deltaTime;
    //        euler.x -= deltaY * rotSpeed * Time.deltaTime;

    //        euler.x = Mathf.Clamp(euler.x, minPitch, maxPitch);

    //        transform.parent.localEulerAngles = new Vector3(0, euler.y, 0);
    //        transform.localEulerAngles = new Vector3(euler.x, 0, 0);

    //    }

    //    if (touch.phase == TouchPhase.Stationary)
    //    {
    //        initialTouch.position = touch.position;
    //    }

    //    else if (touch.phase == TouchPhase.Ended)
    //    {
    //        initialTouch = new Touch();
    //    }
    //}
    #endregion
}
