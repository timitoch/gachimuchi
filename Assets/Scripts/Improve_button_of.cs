using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Improve_button_of : MonoBehaviour
{
    public Slider slider;

    public AudioClip clip;
    public AudioSource audioSource;

    Animator animator;
    private bool stateOfButton = false; // true == on // false == of
    private void Start()
    {
        PlaySound();
        animator = GetComponent<Animator>();
        slider.value = 0.01f;
    }
    private void Update()
    {
        audioSource.volume = slider.value;
    }
    public void Funk()
    {
        if (!stateOfButton)
        {
            animator.SetTrigger("ButtonOn");
            Improve_slider_off.slider.SetTrigger("ButtonOn");
            animator.ResetTrigger("ButtonOff");
            Improve_slider_off.slider.ResetTrigger("ButtonOff");
            AudioListener.volume = 0;
            stateOfButton = true;
        }
        else
        {
            animator.SetTrigger("ButtonOff");
            Improve_slider_off.slider.SetTrigger("ButtonOff");
            animator.ResetTrigger("ButtonOn");
            Improve_slider_off.slider.ResetTrigger("ButtonOn");
            AudioListener.volume = 1;
            stateOfButton = false;

        }
    }
    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
}