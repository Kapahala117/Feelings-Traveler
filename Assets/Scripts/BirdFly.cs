using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour {

    PlayerMovement playermovement;
    GameObject player;
    public float speed = 3f;
    public float height = 0.2f;
    GameObject forw;
   
    
    // Use this for initialization
    void Start () {
        playermovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        forw = GameObject.FindGameObjectWithTag("Forward");
        
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (!playermovement.moving)
        {
            float newY = Mathf.Sin(Time.time * speed);
            transform.position = new Vector3(transform.position.x, (newY * height) + forw.transform.position.y, transform.position.z);
            //transform.LookAt(player.transform);
            Quaternion rot = Quaternion.LookRotation(player.transform.position-transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 2);

        }
        else {
            float newY = Mathf.Sin(Time.time * speed*0.5f);
            transform.position = new Vector3(transform.position.x, (newY * height) + forw.transform.position.y, transform.position.z);
            //transform.LookAt(forward.transform);
            Quaternion rot1 = Quaternion.LookRotation(forw.transform.position-transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot1, Time.deltaTime * 2);
        }

        
            
    }
}
