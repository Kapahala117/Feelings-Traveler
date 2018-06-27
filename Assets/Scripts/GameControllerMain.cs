using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameControllerMain : MonoBehaviour {

    public Canvas pauseCanvas;
    public GameObject helpImage;

	// Use this for initialization
	void Start () {
        pauseCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
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
}
