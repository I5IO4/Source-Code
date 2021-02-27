using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public AudioClip sfxGun;
    public AudioClip sfxBomb;
    public AudioSource sfxAudioPlayer;

    #region Itemdrop
    public GameObject BluePotion;
    GameObject CloneBiuePotion;

    public void MakeBluepotion()
    {
        if (Random.Range(0f, 1f)>0.8)
        {
            CloneBiuePotion = Instantiate(BluePotion);
            CloneBiuePotion.transform.position = transform.position;
        }
    }
    #endregion

    #region สร้างเอฟเฟ็กระเบิด
    public GameObject Bomb;
    GameObject CloneBomb;

    public void generateBomb()
    {
        CloneBomb = Instantiate(Bomb);
        CloneBomb.transform.position = transform.position;
        sfxAudioPlayer.PlayOneShot(sfxBomb);// เสียง
        Destroy(CloneBomb, 0.5f);// ลบ
    }
    #endregion
    private void OnCollisionEnter2D(Collision2D hitObjects)
    {
        if (hitObjects.gameObject.tag.Equals("Em"))
        {
            Destroy(hitObjects.gameObject); //hit คือตัวไปชน
            generateBomb();
            Destroy(gameObject);//game คือ ตัวเราเองในที่นี้คือกระสุน
            MakeBluepotion();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sfxAudioPlayer.PlayOneShot(sfxGun);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
