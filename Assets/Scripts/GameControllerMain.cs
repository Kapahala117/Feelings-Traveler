using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class GameControllerMain : MonoBehaviour {

    public Canvas pauseCanvas,gameCanvas,optionsCanvas,pausaCanvas,opcionesCanvas;
    public GameObject helpImage,joyZone,angerItem,sadnessItem,fearItem;
    public Image joyImage,angerImage,sadnessImage,fearImage;
    public bool angerComplete, joyComplete, sadnessComplete, fearComplete,item;
    public Localization localization;
    public string language;
    GameObject[] deleteZones;
    BirdMovement birdMovement;

  
    // Use this for initialization
    void Start () {

        pauseCanvas.enabled = false;
        optionsCanvas.enabled = false;
        pausaCanvas.enabled = false;
        opcionesCanvas.enabled = false;
        language = "EN";
        localization.SetActiveLanguage("EN", true);
        joyZone.SetActive(false);

        angerItem = GameObject.Find("AngerItem");
        sadnessItem = GameObject.Find("SadnessItem");
        fearItem = GameObject.Find("FearItem");
        angerItem.SetActive(false);
        sadnessItem.SetActive(false);
        fearItem.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (angerComplete)
        {
            deleteZones = GameObject.FindGameObjectsWithTag("OutterAnger");
            foreach (GameObject zone in deleteZones)
            {
                zone.SetActive(false);
            }
            angerImage.enabled = true;
            
            
            
        }
        if (sadnessComplete) {
            deleteZones = GameObject.FindGameObjectsWithTag("OutterSadness");
            foreach (GameObject zone in deleteZones)
            {
                Destroy(zone);
            }
            sadnessImage.enabled = true;
            
        }
        if (fearComplete)
        {
            deleteZones = GameObject.FindGameObjectsWithTag("OutterFear");
            foreach (GameObject zone in deleteZones)
            {
                Destroy(zone);
            }
            fearImage.enabled = true;
        }
        if (joyComplete)
        {
            joyImage.enabled = true;
        }

        if (fearComplete && sadnessComplete && angerComplete) joyZone.SetActive(true);

	}

    public void CompleteAnger()
    {
        angerComplete = true;
    }

    public void CompleteSadness()
    {
        sadnessComplete = true;
    }

    public void CompleteFear()
    {
        fearComplete = true;
    }

    public void CompleteJoy()
    {
        joyComplete = true;
    }

    public void Pause()
    {
        if (language == "EN")
        {
            if (pauseCanvas.enabled == false)
            {
                pauseCanvas.enabled = true;
                Time.timeScale = 0;
            }
            
        }
        else
        {
            if (pausaCanvas.enabled == false)
            {
                pausaCanvas.enabled = true;
                Time.timeScale = 0;
            }
           
        }

    }

    public void Reanude()
    {
        pausaCanvas.enabled = false;
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
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
        
        if (language=="EN")

        {
            optionsCanvas.enabled = true;
            pauseCanvas.enabled = false;
            //optionsCanvas.enabled = false;

        }
        else
        {
            pausaCanvas.enabled = false;
            opcionesCanvas.enabled = true;
            //opcionesCanvas.enabled = false;
        }


    }

    public void Language() {

        if (language == "EN")

        {
            localization.SetActiveLanguage("ES",true);
            language = "ES";
            optionsCanvas.enabled = false;
            opcionesCanvas.enabled = true;

        }
        else  {
            localization.SetActiveLanguage("EN",true);
            language = "EN";
            optionsCanvas.enabled = true;
            opcionesCanvas.enabled = false;
        }

    }

    public void Back() {
       
        if (language == "EN")

        {
            pauseCanvas.enabled = true;
            //pausaCanvas.enabled = false;
            optionsCanvas.enabled = false;

        }
        else
        {
            //pauseCanvas.enabled = true;
            pausaCanvas.enabled = true;
            opcionesCanvas.enabled = false;
        }

    }

}
