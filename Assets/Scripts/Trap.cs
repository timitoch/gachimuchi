using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damageRadius = 2f;
    public int damageAmount = 1;
    Animator animator;
    [SerializeField] float range = 3f;
    private bool isTrapActive = false;
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
            isTrapActive = true;
            yield return new WaitForSeconds(range);
            animator.SetTrigger("state2");
            isDamaging = true;
            yield return new WaitForSeconds(range);
            isDamaging = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isDamaging)
        {
            HeartSystem.healh -= 1;
        }
    }
}
