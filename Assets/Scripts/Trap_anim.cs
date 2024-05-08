using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_anim : Sound
{
    private bool isDamaging = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.CompareTag("Player"))
            {
                PlaySound(0);
                //StartDamage();
                isDamaging = true;
                HeartSystem.healh -= 1;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //StopDamage();
        }
    }


    //// Метод для початку нанесення ушкоджень
    //public void StartDamage()
    //{
    //    isDamaging = true;
    //    HeartSystem.healh -= 1;
    //}

    //// Метод для зупинки нанесення ушкоджень
    //public void StopDamage()
    //{
    //    isDamaging = false;
    //}
}
