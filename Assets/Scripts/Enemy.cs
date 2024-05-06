using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Sound//MonoBehaviour
{
    private bool isDamaging = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))

        {
            PlaySound(0);
            isDamaging = true;
            HeartSystem.healh -= 1;
            isDamaging = false;
        }
    }


}