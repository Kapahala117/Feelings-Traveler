using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("He hecho click, JOPUTA");
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                agent.destination = hit.point;
                Debug.Log("Tengo que moverme, joputilla");
                
            }
        }
    }
}
