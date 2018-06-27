using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public Canvas mainCanvas;
    // Use this for initialization
    void Start () {
        mainCanvas.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame(string newGame)
    {
        SceneManager.LoadScene(newGame);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
