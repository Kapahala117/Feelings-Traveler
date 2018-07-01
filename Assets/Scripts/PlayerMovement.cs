using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    NavMeshAgent agent;
    float z;
    public bool moving;
    public bool talking;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        talking=false;

    }

    void Update()
    {
        if (!talking)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
            if (Input.GetKeyDown(KeyCode.S)) { z = Input.GetAxis("Vertical") * Time.deltaTime * 1.5f; }

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }

        
    }

    void Dialog()
    {
        if (talking) talking = false;
        else talking = true;

    }
}
