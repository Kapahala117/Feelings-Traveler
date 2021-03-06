﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceZone : MonoBehaviour {

    BirdMovement bird;
    public GameObject zone;
    

	// Use this for initialization
	void Start () {

        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdMovement>();
        
        
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bird.playerIn = true;
            bird.zone = zone.GetComponent<Transform>();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            bird.playerIn = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            bird.playerIn = false;
    }
}
