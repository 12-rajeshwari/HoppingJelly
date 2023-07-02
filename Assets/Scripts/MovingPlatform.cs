using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player to enter and exit on moving platform
public class MovingPlatform : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
        
    }
}
