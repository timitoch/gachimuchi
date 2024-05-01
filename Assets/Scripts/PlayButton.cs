using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Level 1");
        //Application.LoadLevel("Level 1");
    }
}
