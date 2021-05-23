using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Anakarakter : MonoBehaviour
{
    public int karaktercan;
    public int karakterzehir;
    public Slider Canbar;
    public Slider zehir;
    private Animator anim;
    private bool Oldum;
    public AudioSource audioSource;
    public AudioClip ruhCikmaSesi;
    public AudioClip KasinmaSesiClip;
    public AudioClip Horlama;
    public AudioClip HomurdamaCli;
    public GameObject GameOver;
    public GameObject ruh;
    void Start()
    {
        karaktercan = 100;
        audioSource = GetComponent<AudioSource>();
        karakterzehir = 0;
        anim = GetComponent<Animator>();
        Canbar.value = karaktercan;
        zehir.value = karakterzehir;
       GameOver.SetActive(false);
    }
    public void TakeDamage(int damageAmount)
    {
        if (Oldum)
        {
            return;
        }
        if (karaktercan > damageAmount && karakterzehir < 100)
        {
            karakterzehir += 20;
            karaktercan -= damageAmount;
            
        }
        if (karaktercan > damageAmount && karakterzehir == 100)
        {
            karakterzehir = 0;
            karaktercan -= damageAmount;
        }
        Canbar.value = karaktercan;
        zehir.value = karakterzehir;

        if (karaktercan<=damageAmount)
        {
            karaktercan -= damageAmount;
            anim.SetBool("dead", true);
            var yer = new Vector2(transform.position.x, -10);
            var asd =Instantiate(ruh, yer, quaternion.identity);
            Oldum = true;
            Destroy(asd, 2f);
            
            Invoke("GameOverGoster", 4.0f);
        }
      
    }

    public void RuhCikmasesiOynat()
    {
        audioSource.PlayOneShot(ruhCikmaSesi, 1f);
    }
    
    public void KasinmaSesi()
    {
        audioSource.PlayOneShot(KasinmaSesiClip, 1f);
    }
    public void Homurdama()
    {
        audioSource.PlayOneShot(HomurdamaCli, 1f);
    }
    
    public void Horla()
    {
        audioSource.PlayOneShot(Horlama, 1f);
    }
    

    void GameOverGoster()
    {
        GameOver.SetActive(true);
    }

    // Update is called once per frame

    void Update()
    {
        if (karaktercan <= 30 && karaktercan > 0 && Oldum!=true)
        {
            anim.SetBool("homurdanma", true);
        }
    }





}
