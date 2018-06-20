using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour {

    public Material enterSkybox;
    public Material exitSkybox;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
       

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            RenderSettings.skybox = enterSkybox;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            RenderSettings.skybox = exitSkybox;
    }
}
