using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damageRadius = 2f;
    public int damageAmount = 1;
    Animator animator;
    [SerializeField] float range = 3f;
    private bool isDamaging = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(TrapAnimation());
    }

    IEnumerator TrapAnimation()
    {
        while (true)
        {
            animator.SetTrigger("state1");
            //isDamaging = false;
            yield return new WaitForSeconds(range);
            animator.SetTrigger("state2");
            //isDamaging = true;
            yield return new WaitForSeconds(range);
        }
    }

    //public void DamagePlayer()
    //{
    //    if (isDamaging)
    //    {
    //        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);
    //        foreach (Collider2D collider in colliders)
    //        {
    //            if (collider.CompareTag("Player"))
    //            {
    //                HeartSystem.healh -= damageAmount;
    //            }
    //        }
    //    }
    //}
}
