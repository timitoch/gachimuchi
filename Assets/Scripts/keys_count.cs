using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class keys_count : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.key_count += 1;
            Destroy(gameObject);
        }
    }
}
