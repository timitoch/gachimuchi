using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;



public class key_check : MonoBehaviour
{
    private Collider2D Collider2D;
    private Animator animator;

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
            StartCoroutine(SceneLoad(other.gameObject));
        }
    }

    IEnumerator SceneLoad(GameObject player)
    {
        yield return new WaitForSeconds(2);

        // поточна сцена
        string currentScene = SceneManager.GetActiveScene().name;

        // наступна
        string nextScene = "";

        switch (currentScene)
        {
            case "Level 1":
                nextScene = "Level 2";
                break;
            case "Level 2":
                nextScene = "Level 3";
                break;
            case "Level 3":
                nextScene = "Level 4";
                break;
            case "Level 4":
                nextScene = "Level 5";
                break;
            default:
                Debug.Log("Немає наступної сцени");
                break;
        }

        
        if (nextScene != "")
        {
            
           
            SceneManager.LoadScene(nextScene);
        }
    }
}
