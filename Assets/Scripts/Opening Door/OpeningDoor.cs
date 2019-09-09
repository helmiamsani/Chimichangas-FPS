using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    public GameObject player;
    public Transform door;

    public float doorSpeed;
    public float closeDoorAfter = 8f;

    private bool isPlyrInside = false;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlyrInside)
        {
            time += Time.deltaTime;

            door.Translate(new Vector3(doorSpeed, 0, 0) * Time.deltaTime);

            if (time > closeDoorAfter)
            {
                isPlyrInside = false;
                //Debug.Log("Time is out Main Door Should Stop");
            }
        }

        else if(!isPlyrInside)
        {
            return;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            isPlyrInside = true;
        }
    }
}
