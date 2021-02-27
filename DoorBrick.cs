using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBrick : MonoBehaviour
{
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("potion Blue");
        count = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void checkItem(int num)
    {
        count -= num;
        Debug.Log(count);

        if (count == 0)
        {
            gameObject.GetComponent<Animation>().Play("New Door");
        }

    }
}
