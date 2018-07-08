using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Fungus;

public class NpcController : MonoBehaviour {

    GameObject player;
    public Transform angerDest, fearDest, sadnessDest;
    public GameControllerMain gameController;
    public Flowchart flowchart;
    public bool AngerC, SadnessC, FearC,Item;
    public BirdMovement birdMovement;
    NavMeshAgent nav;
    bool AngerMoved, SadnessMoved, FearMoved;
    PlayerMovement playerMovement;
    Animator anim;

	// Use this for initialization
	void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player");
        nav = this.GetComponent<NavMeshAgent>();
        SadnessMoved = false;
        AngerMoved = false;
        FearMoved = false;
        playerMovement = player.GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        SadnessC = gameController.sadnessComplete;
        AngerC = gameController.angerComplete;
        FearC = gameController.fearComplete;
        Item = gameController.item;

        if (this.name == "Father" && !birdMovement.playerIn && AngerC && !AngerMoved) {
            nav.Warp(angerDest.position);
            AngerMoved = true;
            anim.SetBool("End", true);
                }
        if (this.name == "Daughter" && !birdMovement.playerIn && FearC && !FearMoved) {
            nav.Warp(fearDest.position);
            FearMoved = true;
            anim.SetBool("End", true);
        }
        if (this.name == "Son" && !birdMovement.playerIn && SadnessC && !SadnessMoved)
        {
            nav.Warp(sadnessDest.position);
            SadnessMoved = true;
            anim.SetBool("End", true);
        }

        if (Input.GetMouseButtonDown(0)&& Time.timeScale == 1 && !playerMovement.talking)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(player.transform.position,this.transform.position)<2.0f) { 
                    if (hit.transform.gameObject.tag == "Npc")
                    {
                        switch (this.name)
                        {
                            case "Father":
                                if (Item)
                                {
                                    flowchart.SendFungusMessage("AngerGotItem");
                                    gameController.item = false;
                                }
                                else if (SadnessC && FearC && AngerC)
                                {
                                    flowchart.SendFungusMessage("GameCompleted");
                                }
                                else if (AngerC)
                                {
                                    flowchart.SendFungusMessage("AngerGotItem");
                                }
                                else if (FearC && !SadnessC)
                                {
                                    flowchart.SendFungusMessage("AngerFear");
                                    gameController.angerItem.SetActive(true);
                                }
                                else if (SadnessC &&! FearC)
                                {
                                    flowchart.SendFungusMessage("AngerSadness");
                                    gameController.angerItem.SetActive(true);
                                }
                               
                                else if (SadnessC&&FearC)
                                {
                                    flowchart.SendFungusMessage("AngerBoth");
                                    gameController.angerItem.SetActive(true);
                                }
                             
                                else {
                                    flowchart.SendFungusMessage("AngerOnly");
                                    gameController.angerItem.SetActive(true);

                                }
                                
                                break;
                            case "Daughter":
                                if (Item)
                                {
                                    flowchart.SendFungusMessage("FearGotItem");
                                    gameController.item = false;

                                }
                                else if (SadnessC && FearC && AngerC)
                                {
                                    flowchart.SendFungusMessage("GameCompleted");
                                }
                                else if (FearC)
                                {
                                    flowchart.SendFungusMessage("FearGotItem");
                                }
                                else if (AngerC && !SadnessC)
                                {
                                    flowchart.SendFungusMessage("FearAnger");
                                    gameController.fearItem.SetActive(true);
                                }
                                else if (SadnessC && !AngerC)
                                {
                                    flowchart.SendFungusMessage("FearSadness");
                                    gameController.fearItem.SetActive(true);
                                }

                                else if (SadnessC && AngerC)
                                {
                                    flowchart.SendFungusMessage("FearBoth");
                                    gameController.fearItem.SetActive(true);
                                }
                               
                                else
                                {
                                    flowchart.SendFungusMessage("FearOnly");
                                    gameController.fearItem.SetActive(true);
                                }
                                break;
                            case "Son":
                                if (Item)
                                {
                                    flowchart.SendFungusMessage("SadnessGotItem");
                                    gameController.item = false;
                                }
                                else if (SadnessC && FearC && AngerC)
                                {
                                    flowchart.SendFungusMessage("GameCompleted");
                                }
                                else if(SadnessC)
                                {
                                    flowchart.SendFungusMessage("SadnessGotItem");
                                }
                                else if (FearC && !AngerC)
                                {
                                    flowchart.SendFungusMessage("SadnessFear");
                                    gameController.sadnessItem.SetActive(true);
                                }
                                else if (AngerC && !FearC)
                                {
                                    flowchart.SendFungusMessage("SadnessAnger");
                                    gameController.sadnessItem.SetActive(true);
                                }

                                else if (AngerC && FearC)
                                {
                                    flowchart.SendFungusMessage("SadnessBoth");
                                    gameController.sadnessItem.SetActive(true);
                                }
                             
                                else
                                {
                                    flowchart.SendFungusMessage("SadnessOnly");
                                    gameController.sadnessItem.SetActive(true);
                                }
                                break;

                        }
                       
                    }
                }
            }
        }
		
	}
}
