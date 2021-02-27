using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public AudioSource sfxSpeaker; // เชื่อมต่อกับ AudioSoure SFX
    public AudioClip sfxClip; // เชื่อมเสียง SFX ติดต่อกับเสียงคลิป
    public AudioSource bgmSpeaker; //เชื่ยม BGM source
    public Slider BGMSlider; //เชื่อมโยงไสเตอร์ bgm หน้า Option
    public Slider SFxSlider; //เชื่อมโยงไสเตอร์ sfx หน้า Option
    public static float audiotime; //เพลงต่อเนื่อง บันทึกค่าเวลาเสียงตอนเปลี่ยน

    public GameObject ESCpanel; //เชื่อม ESCpanel
    bool onoffpanelESC= false; // ตั้งบูลีนเป็น 0 

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            onoffpanelESC = !onoffpanelESC; // สร้างเพื่อให้มีการสลับค่า true และ false
            ESCpanel.SetActive(onoffpanelESC);// กดแล้วจะสลับค่า 0 และ1
        }
    }
    void Start()
    {
        
        bgmSpeaker.volume = PlayerPrefs.GetFloat("BGMVolume");//โหลดเซฟค่า
        sfxSpeaker.volume = PlayerPrefs.GetFloat("SFXVolume");
        if (SceneManager.GetActiveScene().name == "Option") //สำหรับหน้า option menu ตอนเปิดoption menu
        {
            BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");// โหลดรูปเสียง
            SFxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }
  

    
    public void setBgmV() // ปรับเสียงมากน้อย แบ็คกราว
    {
        bgmSpeaker.volume = BGMSlider.value;
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);

    }
    public void setsfxV() // ปรับเสียงมากน้อย เอฟเฟ็ก
    {
        sfxSpeaker.volume = SFxSlider.value;
        PlayerPrefs.SetFloat("SFXVolume", SFxSlider.value);
        sfxSpeaker.PlayOneShot(sfxClip);
    }
    //เปลี่ยนป็นตัวเลขใน Build settting 
    public void GoToGamelevel() //ชื่อฟังชั่น
    {
        sfxSpeaker.PlayOneShot(sfxClip);
        SceneManager.LoadScene("PlayGame");//ไปหน้าเล่นเกม
    }
    public void GoToOption()
    {
        sfxSpeaker.PlayOneShot(sfxClip);

        SceneManager.LoadScene("Option");//ไปหน้า Option
    }
    public void GoToCredit()
    {
        sfxSpeaker.PlayOneShot(sfxClip);
        SceneManager.LoadScene("Credit");//ไปหน้า Credit
    }
    public void GoToHowToPlay()
    {
        sfxSpeaker.PlayOneShot(sfxClip);
        SceneManager.LoadScene("HowToPlay");//ไปหน้า how to play
    }
    public void Exit()
    {
        sfxSpeaker.PlayOneShot(sfxClip); //ลิงค์คลิปเสียง 
        
        Application.Quit(); //ออกจากเกม
    }
    public void Back()
    {
        sfxSpeaker.PlayOneShot(sfxClip);
        SceneManager.LoadScene("MainMenu"); //ปุ๋มกลับ
    }
    
}