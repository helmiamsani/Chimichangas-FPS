using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Movement move;

    private void Start()
    {
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    public void OnMouseDown()
    {
        move._aboutToJump = true;
        move.Jump(move.jumpSpeed);
    }
}
