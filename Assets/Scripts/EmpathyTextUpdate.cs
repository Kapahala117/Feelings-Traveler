using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmpathyTextUpdate : MonoBehaviour
{

    Text points;
    int empathy;

    // Use this for initialization
    void Start()
    {
        points = this.GetComponent<Text>();
        empathy = 0;
        UpdatePoints();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdatePoints()
    {
        points.text = "Empathy: " + empathy;
    }

    public void UpdateEmpathy(int n) {
        empathy += n;
        UpdatePoints();
    }
}