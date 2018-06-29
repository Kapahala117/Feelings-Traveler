using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerPlayer : MonoBehaviour {

    Animator playerAnimator;
    Rigidbody playerRb;
    PlayerMovement playermovement;
	// Use this for initialization
	void Start () {
        playerAnimator = this.GetComponent<Animator>();
        playerRb = this.GetComponent<Rigidbody>();
        playermovement = this.GetComponent <PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {

        if ((Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)) && !playermovement.talking)
        {
            playerAnimator.SetBool("Moving", true);
            playerAnimator.SetBool("MovingB", false);
            playermovement.moving = true;
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !playermovement.talking)
        {
            playerAnimator.SetBool("MovingB", true);
            playerAnimator.SetBool("Moving", false);
            playermovement.moving = true;

        }
        else if (Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerAnimator.SetBool("Moving", false);
            playerAnimator.SetBool("MovingB", false);
            playermovement.moving = false;
        }
		
	}
}
