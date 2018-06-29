﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Fungus;

public class BirdMovement : MonoBehaviour {

    GameObject player;
    NavMeshAgent nav;
    public bool playerIn;
    PlayerMovement playermovement;
    GameObject inner;
    public Flowchart flowchart;
 
   
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = this.GetComponent<NavMeshAgent>();
        nav.enabled = true;
        inner = GameObject.FindGameObjectWithTag("Inner");
        playermovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (playerIn) {
            nav.SetDestination(inner.transform.position);
            flowchart.SendFungusMessage("FollowBird");
            
        }
            
        else {
            nav.SetDestination(player.transform.position);
            
        }

    }
	
}
