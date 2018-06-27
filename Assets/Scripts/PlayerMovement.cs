using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    NavMeshAgent agent;
    float z;
    public bool moving;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;

    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        if (Input.GetKeyDown(KeyCode.S)){ z = Input.GetAxis("Vertical") * Time.deltaTime *1.5f; }

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        
    }
}
