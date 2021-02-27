using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   public int count;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("KeyItem");
        count = obj.Length;
        Debug.Log(count);

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
            gameObject.GetComponent<Animation>().Play("DoorOpen");
        }

    }
}

