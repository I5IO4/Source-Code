using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel2Maneger : MonoBehaviour
{
    
    public GameObject bigBluePrefab; //ติดต่อprefab
    public GameObject SpawnPointitem; // ติดต่อspawnpointitem
    GameObject ClonePotion;

    public void generatepotion()
    {
        ClonePotion = Instantiate(bigBluePrefab);
        ClonePotion.transform.position = SpawnPointitem.transform.position; //กำหนดตำแห่นงเกิด
        Destroy(ClonePotion, 3f);
    }
    IEnumerator ItemDelay() //ปล่อยไอเทมตามเวลา วนลูปตลอด
    {
        while (true)
        {
            generatepotion();
            float randtimepotion = Random.Range(3, 6); //แรนด้อม
            yield return new WaitForSeconds(randtimepotion);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ItemDelay");
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeManager.timeValue < 1)
        {
            TimeManager.timeValue = 0; //ตัวเลขเวลาไม่ให้ติดลบ
            Time.timeScale = 0; //โค๊ดหยุดเวลา ตวามเร็วเกม
        }
    }
}
