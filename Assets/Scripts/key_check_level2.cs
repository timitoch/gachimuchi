using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class key_check_level2 : MonoBehaviour
{
    private Collider2D Collider2D;
    private Animator animator;
    private MonoBehaviour monoBehaviour;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Player.key_count == 1)
        {
            animator.SetTrigger("Opened");
            Collider2D.enabled = false;
            Player.key_count = 0;
            StartCoroutine(scenelod());
        }
    }
    IEnumerator scenelod()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level 2");

    }
}
