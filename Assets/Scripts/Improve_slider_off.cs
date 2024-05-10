using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Improve_slider_off : MonoBehaviour
{
    public static Animator slider;
    private void Awake()
    {
        slider = GetComponent<Animator>();
    }
}
