using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    GameObject player;
    public GameControllerMain gameController;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(player.transform.position, this.transform.position) < 15.0f)
                {
                    if (hit.transform.gameObject.tag == "Item") {
                        gameController.item = true;
                        gameController.angerItem.SetActive(false);
                        gameController.sadnessItem.SetActive(false);
                        gameController.fearItem.SetActive(false);
                        
                    }
                }
            }
        }

    }
}
