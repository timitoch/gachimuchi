using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_anim : MonoBehaviour
{
    public float damageRadius = 2f;
    public int damageAmount = 1;

    public void DamagePlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                HeartSystem.healh -= damageAmount;
            }
        }
    }
}
