﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFloor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Eraser")
        {
            Destroy(gameObject);
        }
    }
}
