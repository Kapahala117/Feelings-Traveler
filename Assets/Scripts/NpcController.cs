using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		
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
                        Debug.Log("HOLIS");
                        //HABLAAAARRR
                    }
                }
            }
        }
		
	}
}
