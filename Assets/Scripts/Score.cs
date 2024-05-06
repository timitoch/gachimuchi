using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Score : Sound //MonoBehaviour
{
    [SerializeField] int price;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            
            ScoreManager.score += price;
            PlaySound(0); 
            Destroy(gameObject);
            
        }
    }
}
