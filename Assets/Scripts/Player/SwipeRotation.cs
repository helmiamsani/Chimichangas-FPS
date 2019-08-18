using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRotation : MonoBehaviour
{
    // >>> MANNY PUNYA <<<
    private Touch initialTouch = new Touch();

    public Camera mainCamera;
    public Transform player;
    public float minPitch = -80f, maxPitch = 80f;
    public float rotSpeed = 0.8f;

    private Vector2 euler;
    // Start is called before the first frame update
    void Start()
    {
        euler = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Rect bounds = new Rect(0,0,);

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                initialTouch = touch;
                Debug.Log("holdTouch is on");
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                Debug.Log("holdTouch is stationary");
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

                Debug.Log("holdTouch is moved");
            }

            if (touch.phase == TouchPhase.Ended)
            {
                initialTouch = new Touch();
                Debug.Log("holdTouch is out");
            }
        }
    }

    public void Rotate()
    {
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
}
