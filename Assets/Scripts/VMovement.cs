using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMovement : MonoBehaviour
{
    public float speed; 
    public Animator animator;
    
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("cut_down_tree");
            //PlaySound(sounds[0]);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            animator.SetTrigger("water_plant");

        }
        Vector3 direction = new Vector3(horizontal, vertical).normalized; // Нормализация вектора направления
        AnimateVMovement(direction);
        transform.position += direction * speed * Time.deltaTime;

        
    }

        void AnimateVMovement(Vector3 direction)
    {
        if(animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("Horizontal", direction.x);
                animator.SetFloat("Vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }



  

    

    
}
