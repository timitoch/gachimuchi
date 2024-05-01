using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isDamaging = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))

        {
            isDamaging = true;
            HeartSystem.healh -= 1;
            isDamaging = false;
        }
    }


}