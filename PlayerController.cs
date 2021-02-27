using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
    
{
    public Animator PlayerAnimator;
    float speed = 8f; //กำหนดคำเร็วให้กับตัวละคร
    bool isGround = false; // ตรวจสอบว่าอยู่ยนพื้นไหม ถ้า false แสดงว่าไม่อยู่
    private Vector3 spawnpoint;
    [SerializeField] GameObject objgate;
    [SerializeField] GameObject objsgate;

    #region Generate Bullet สร้างกระสุน

    public GameObject BulletPrefabs; // ต่อติดกับ bullprefab
    public GameObject BulletOut; // ต่อติดกับที่เชื่อมplayer
    GameObject cloneBullet; // สร้างโครนกระสุน

    public void generateBullet()
    {
        cloneBullet = Instantiate(BulletPrefabs); //โตรนเท่ากับก็อปกระสุนพีแฟ็ต
        cloneBullet.transform.position = BulletOut.transform.position; //ให้ตัวโครนออกทางที่เรากำหนด
       
        cloneBullet.transform.localScale = new Vector2(
            transform.localScale.x*0.5f,0.5f); //กระสุนเท่ากับตัวละคร/หันหน้ากระสุน
     //   cloneBullet.transform.Rotate(0, 0, transform.localScale.z * 90);//ยิงบน
        
        cloneBullet.GetComponent<Rigidbody2D>().AddForce(
            new Vector2(transform.localScale.x, 0)* 400f);// ปล่อยแรงยิง/หันซ้ายหันขวายิงตามที่หัน

        Destroy(cloneBullet, 1.5f); //ลบกระสุนเพิ่มหน่วยความจำ
    }
    #endregion
   

    private void OnCollisionEnter2D(Collision2D hitobjects)// เช็คการอยู่กับวัตถุ
    {
        if (hitobjects.gameObject.tag == "Ground") //ถ้ามันชัน.กับเกมอ็อบ.ที่แท็ค==กราว
        {
            PlayerAnimator.SetBool("isjump", false);
            isGround = true;
        }
        if (hitobjects.gameObject.tag == "potion Blue")
        {//ชนขวดหายไป
            ScoreManager.scoreValue += 1;
            Destroy(hitobjects.gameObject);
            objsgate.SendMessage("checkItem", 1);
        }
        if (hitobjects.gameObject.name == "Door")
        {//ประตูวาป
            SceneManager.LoadScene("PlayGame2");
        }
        if (hitobjects.gameObject.name == "Door1")
        {//ประตูวาป
            SceneManager.LoadScene("PlayGame3");
        }
        if (hitobjects.gameObject.name == "Door3")
        {//ประตูวาป
            SceneManager.LoadScene("Credit");
        }
        if (hitobjects.gameObject.tag == "Em")
        {
            LifeManager.LifeValue -= 10;
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * 150);
        }
        if (hitobjects.gameObject.name == "die")
        {
          gameObject.transform.position = spawnpoint;
        }
        if (hitobjects.gameObject.name == "Jumpkill")
        {
          gameObject.transform.position =  spawnpoint;
        }
        if (hitobjects.gameObject.tag == "KeyItem")
        {
            objgate.SendMessage("checkItem", 1);
            Destroy(hitobjects.gameObject);
        }
        if (hitobjects.gameObject.name == "dieee")
        {
            SceneManager.LoadScene("PlayGame2");
        }
    }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame

        void Update()
        {
            
            #region moveeeeeee
            float dirx, diry; // ตั้งค่าตัวแปรเพื่อเก็บค่า ค่า +,- 
            dirx = Input.GetAxis("Horizontal"); // ค่าแกนX แนวนอน ซ้ายขวา มีค่า -1 0 1

            PlayerAnimator.SetFloat("walk", Mathf.Abs(dirx)); //แอนิเมะชันเดิน

            diry = Input.GetAxis("Vertical");//ค่าแกนY แนวตั้ง ซ้ายขวา มีค่า -1 0 1
            transform.Translate(dirx * speed * Time.deltaTime,  //x การเคลื่อนที่
                                diry * speed * Time.deltaTime, //y การเคลื่อนที่
                                0f); //z การเคลื่อนที่

        #endregion

        #region การหันหน้าเวลาเดิน
        if (dirx > 0) { transform.localScale = new Vector3(1, 1, 1); }
        if (dirx < 0) { transform.localScale = new Vector3(-1, 1, 1); }
        #endregion

        /*#region Control Move Direction การควบคุมหัน
        if (dirx >= 0) //สปินหันซ้าย *****มี = จะไม่หันซ้ายถาวรตอนหัน*****
            {
                transform.localScale = new Vector3(1f, 1f);
            }
            else if (dirx < 0)//หันขวา
            {
                transform.localScale = new Vector3(-1f, 1f);
            }
            #endregion*/

         #region jump
            if (Input.GetKeyDown(KeyCode.Space) && isGround)//กดspacebar และ ยืนบนกราวเป็นtrue
            {
            PlayerAnimator.SetBool("isjump", true);
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector3
                    (0f, //ใส่แรงที่แกน x
                    500f,   //ใส่แรงที่แกน y
                    0f));//ใส่แรงที่แกน z
                isGround = false; //เพื่อให้ค่าเป็นfalse เพราะไม่ได้ยืนบนพื้นแล้ว โดดต่อเนื่องไม่ได้
            }
        #endregion

        #region Fire;
        if (Input.GetButtonDown("Fire1")
            && SceneManager.GetActiveScene().buildIndex >= 5) 
        {
            generateBullet();
        }
        #endregion
       
        

    }
     
}
