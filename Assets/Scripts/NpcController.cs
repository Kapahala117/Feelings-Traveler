using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NpcController : MonoBehaviour {

    GameObject player;
    public GameControllerMain gameController;
    public Flowchart flowchart;
    public bool AngerC, SadnessC, FearC;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        SadnessC = gameController.sadnessComplete;
        AngerC = gameController.angerComplete;
        FearC = gameController.fearComplete;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
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
                            case "AngryChar":
                                if (FearC && !SadnessC)
                                {
                                    flowchart.SendFungusMessage("AngerFear");
                                }
                                else if (SadnessC &&! FearC)
                                {
                                    flowchart.SendFungusMessage("AngerSadness");
                                }
                               
                                else if (SadnessC&&FearC)
                                {
                                    flowchart.SendFungusMessage("AngerBoth");
                                }
                                else {
                                    flowchart.SendFungusMessage("AngerOnly");
                                }
                                
                                break;
                            case "FearChar":
                                flowchart.SendFungusMessage("FearDialog");
                                break;
                            case "SadChar":
                                flowchart.SendFungusMessage("SadnessDialog");
                                break;

                        }
                       
                    }
                }
            }
        }
		
	}
}
