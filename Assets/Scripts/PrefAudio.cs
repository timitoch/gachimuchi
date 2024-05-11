using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefAudio : MonoBehaviour
{
    public LayerMask layer;
    public AudioClip soundClip;
    public Improve_button_of aboba;

    private void Awake()
    {
        GameObject obj = GameObject.Find("NameOfTheObjectWithImprove_button_of");
        if (obj != null)
        {
            aboba = obj.GetComponent<Improve_button_of>();
        }
    }

    private void Start()
    {
        aboba.PlaySound();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & layer) != 0)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = soundClip;
            audioSource.Play();
            audioSource.volume = 0.1f;
            Destroy(audioSource, soundClip.length);
        }
    }
}
