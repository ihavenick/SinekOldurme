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
        }
      
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
