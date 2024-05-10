using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Animator animator; //  Animator 

    public void OnButtonClick()
    {
        StartCoroutine(LoadLevelAfterAnimation());
    }

    IEnumerator LoadLevelAfterAnimation()
    {
        animator.SetTrigger("click_on"); // ������ 
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); //   ������� �����������
        SceneManager.LoadScene("Level 1");
    }
}
