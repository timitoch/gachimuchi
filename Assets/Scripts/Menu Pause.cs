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
    protected bool panalCheack;

    public void PauseButtonPressed()
    {
        panalCheack = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ContinueButtonPressed()
    {
        panalCheack = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
