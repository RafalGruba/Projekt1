﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportOut;
    public GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = teleportOut.transform.position;
    }
}
