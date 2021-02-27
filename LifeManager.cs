using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeManager : MonoBehaviour
{
    public static int LifeValue = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = LifeValue;
        if (GetComponent<Slider>().value <= 0)
        {
            //GetComponentInChildren<>
        }
    }
}
