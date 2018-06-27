using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour {

    public Material enterSkybox;
    //public Material exitSkybox;
    public Color skyColor, equatorColor, groundColor;
    public Color exitSkyColor,exitEquatorColor,exitGroundColor;
    float changeTime;
    public float blendFactor;
    float tIn,tOut;
    public bool playerIn,playerOut;
    // Use this for initialization
    void Start () {
        changeTime = 0.3f;
        blendFactor = 0f;
        //exitSkyColor = RenderSettings.ambientSkyColor;
        //exitEquatorColor = RenderSettings.ambientEquatorColor;
        //exitGroundColor = RenderSettings.ambientGroundColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn)
        {
            //tOut = 0;
            if (tIn < 1)
            {
                tIn += Time.deltaTime * 0.3f;
            }

            blendFactor = Mathf.Lerp(1, 0, tIn);
            RenderSettings.skybox.SetFloat("_Blend", blendFactor);

            RenderSettings.ambientSkyColor = Color.Lerp(RenderSettings.ambientSkyColor, skyColor, tIn*0.5f);
            RenderSettings.ambientEquatorColor = Color.Lerp(RenderSettings.ambientEquatorColor, equatorColor, tIn*0.5f);
            RenderSettings.ambientGroundColor = Color.Lerp(RenderSettings.ambientGroundColor, groundColor, tIn*0.5f);
            

        }
        else if (playerOut){
            
            //tIn = 0;
            //blendFactor = 0;
            if (tOut < 1)
            {
                tOut += Time.deltaTime * 0.3f;
            }
            blendFactor = Mathf.Lerp(0, 1, tOut);
            RenderSettings.skybox.SetFloat("_Blend", blendFactor);

            RenderSettings.ambientSkyColor = Color.Lerp(RenderSettings.ambientSkyColor, exitSkyColor, changeTime * Time.deltaTime);
            RenderSettings.ambientEquatorColor = Color.Lerp(RenderSettings.ambientEquatorColor, exitEquatorColor, changeTime * Time.deltaTime);
            RenderSettings.ambientGroundColor = Color.Lerp(RenderSettings.ambientGroundColor, exitGroundColor, changeTime * Time.deltaTime);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //blendFactor = 0;
            tOut = 0;
            playerIn = true;
            playerOut = false;
            RenderSettings.skybox = enterSkybox;

        }
            
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIn = true;
            //playerOut = false;
            //RenderSettings.skybox = enterSkybox;

        }
    }

    

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            blendFactor = 1;
            tIn = 0;
            playerIn = false;
            playerOut = true;
            //RenderSettings.skybox = enterSkybox;
            //RenderSettings.skybox.SetFloat("_Blend", blendFactor);
        }
    }
}
