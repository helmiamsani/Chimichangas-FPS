using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    public GameObject player;
    public Transform mainDoor;

    public float doorSpeed;

    private bool isPlyrInside = false;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (isPlyrInside)
        {
            mainDoor.Translate(new Vector3(-doorSpeed, 0, 0) * Time.deltaTime);
        }
        else if(!isPlyrInside)
        {
            Vector3 stopPos = new Vector3(-8f, 0.4f, 11f);
            if (mainDoor.position == stopPos)
            {
                doorSpeed = 0;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            if(time <= 10f)
            {
                isPlyrInside = true;
                Debug.Log("Player is inside the range");
            }

            if (time > 10f)
            {
                isPlyrInside = false;
                Debug.Log("Time is out Main Door Should Stop");
            }
        }
    }
}
