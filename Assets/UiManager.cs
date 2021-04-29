using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject homeCanvas;
    public GameObject aboutCanvas;
    // public Canvas settingCanvas;
    public GameObject highScoreCanvas;

    private void Awake()
    { 
        highScoreCanvas.SetActive(false);
        aboutCanvas.SetActive(false);
        homeCanvas.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ActivateHomeCanvas()
    {
        highScoreCanvas.SetActive(false);
        aboutCanvas.SetActive(false);
        homeCanvas.SetActive(true);
    }

    public void ActivateAboutCanvas()
    {
        highScoreCanvas.SetActive(false);
        aboutCanvas.SetActive(true);
        homeCanvas.SetActive(false);
    }
    
    public void ActivateHighScoreCanvas()
    {
        highScoreCanvas.SetActive(true);
        aboutCanvas.SetActive(false);
        homeCanvas.SetActive(false);
    }





}
