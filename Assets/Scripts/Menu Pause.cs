using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject stopButton;
    private bool panalCheack;


    //
    //animztion 
    public Animator buttonAnimator;// Animatorfff

    public void PauseButtonPressed()
    {
        panalCheack = true;
        pausePanel.SetActive(true);
        StartCoroutine(AfterAnimation());
        Time.timeScale = 0f;
    }

    IEnumerator AfterAnimation()
    {
        buttonAnimator.SetTrigger("click_on");
        yield return new WaitForSecondsRealtime(buttonAnimator.GetCurrentAnimatorStateInfo(0).length);
        
    }

    //

    private void Start()
    {
        PlaySound();
    }
    
    public void ContinueButtonPressed()
    {
        panalCheack = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // audio 
    public Sprite audioOn;
    public Sprite audioOff;
    public GameObject buttonAudio;

    public Slider slider;

    public AudioClip clip;
    public AudioSource audioSource;

    private void Update()
    {
        if (pausePanel != null)
        {
            if (panalCheack == true)
                stopButton.SetActive(false);
            else stopButton.SetActive(true);
        }

        audioSource.volume = slider.value;
    }
    public void OnOffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = audioOn;
        }
    }
    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }


    
    
}
