using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Animator animator; // додайте Animator через Inspector

    public void OnButtonClick()
    {
        StartCoroutine(LoadLevelAfterAnimation());
    }

    IEnumerator LoadLevelAfterAnimation()
    {
        animator.SetTrigger("click_on"); // виклик анімації
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // чекаємо, поки анімація завершиться
        SceneManager.LoadScene("Level 1");
    }
}
