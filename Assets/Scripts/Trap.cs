using System.Collections;
using UnityEngine;

public class Trap : Sound //MonoBehaviour
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

    private IEnumerator TrapAnimation()
    {
        while (true)
        {
            isDamaging = !isDamaging;
            yield return new WaitForSeconds(3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isDamaging)
        {
            PlaySound(0);
            HeartSystem.healh -= 1;
        }
    }
}
