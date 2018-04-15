using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour {


    public void BackMain() {

        SceneManager.LoadScene(0);
    }

    public void Fear() {
        SceneManager.LoadScene(1);
    }
    public void Anger()
    {
        SceneManager.LoadScene(2);
    }
    public void Joy()
    {
        SceneManager.LoadScene(3);
    }
    public void Sadness()
    {
        SceneManager.LoadScene(4);
    }
}
