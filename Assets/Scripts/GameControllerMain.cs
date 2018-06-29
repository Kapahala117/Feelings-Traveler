using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class GameControllerMain : MonoBehaviour {

    public Canvas pauseCanvas,gameCanvas,optionsCanvas;
    public GameObject helpImage;
    public Image joyImage,angerImage,sadnessImage,fearImage;
    public bool angerComplete, joyComplete, sadnessComplete, fearComplete;
    public Localization localization;

	// Use this for initialization
	void Start () {

        pauseCanvas.enabled = false;
        optionsCanvas.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (angerComplete) angerImage.enabled=true; 
        if (sadnessComplete) sadnessImage.enabled = true; ;
        if (fearComplete) fearImage.enabled = true; ;
        if (joyComplete) joyImage.enabled = true; 
	}

    public void Pause()
    {
        if (pauseCanvas.enabled == false)
        {
            pauseCanvas.enabled = true;
            Time.timeScale = 0;
        }
        else
        {
            pauseCanvas.enabled = false;
            Time.timeScale = 1;
        }

    }
    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Help()
    {
        helpImage.SetActive(true);
    }

    public void Options() {
        pauseCanvas.enabled = false;
        optionsCanvas.enabled = true;

    }

    public void Language() {

        if (localization.ActiveLanguage == "EN") localization.SetActiveLanguage("ES", true);
        else localization.SetActiveLanguage("EN", true);

    }

    public void Back() {
        pauseCanvas.enabled = true;
        optionsCanvas.enabled = false;

    }

}
