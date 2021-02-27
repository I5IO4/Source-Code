using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static float timeValue = 120 ; 
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Text>().text = "Time : " + timeValue;   
    }

    // Update is called once per frame
    void Update()
    {
        timeValue -= Time.deltaTime;
        GetComponent<Text>().text = "" + timeValue.ToString("f0");
    }
}
