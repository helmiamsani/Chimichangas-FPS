using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [Header("Which Platform?")]
    public bool PC;
    public bool Mobile;

    private void Awake()
    {
        if (PC)
        {
            Mobile = false;
        }
        else
        {
            PC = false;
        }
    }
}
