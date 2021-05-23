using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anakarakter : MonoBehaviour
{
    public int karaktercan;
    public int karakterzehir;
    public Slider Canbar;
    public Slider zehir;
    private Animator anim;
    public GameObject ruh;
    void Start()
    {
        karaktercan = 100;
        karakterzehir = 0;
        anim = GetComponent<Animator>();
        Canbar.value = karaktercan;
        zehir.value = karakterzehir;
       
    }
    public void TakeDamage(int damageAmount)
    {
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
            var asd =Instantiate(ruh, transform);
            Destroy(asd, 2f);
        }
      
    }

    // Update is called once per frame

    void Update()
    {
        if (karaktercan <= 30 && karaktercan > 0)
        {
            anim.SetBool("homurdanma", true);
        }
    }





}
