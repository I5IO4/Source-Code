using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelManeger3 : MonoBehaviour
{
    #region สุ่มมอน
    public GameObject Headprefabs; //ติดต่อพีแฟ็ต
    //ไม่ใช้SpawnPoint
    GameObject cloneHead; //โครนพีแฟ็ต

    public void generateHead()
    {
        cloneHead = Instantiate(Headprefabs); //โคลน
        cloneHead.transform.position = new Vector3(Random.Range(-11.14f, 4.15f), 0.53f, 0f);//ตำแหน่งสุ่ม
    }
    IEnumerator waitforHead()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            generateHead();
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitforHead());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
