using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class TouchAndDestroy : MonoBehaviour
{
    public GameObject hand;
    public GameObject Terlik;
    public Texture2D cursor;
    Animator myAnimator;
    private float timeBtwShots;
    public float startTimeBtwShots;


    // Use this for initialization
    void Start()
    {
        myAnimator = hand.GetComponent<Animator>();
    }

    public void TerlikOlustur(LeanFinger LF)
    {
        var ray = LF.GetRay();
         RaycastHit hit;
         if (Physics.Raycast(ray, out hit, Mathf.Infinity))
         {
             Debug.Log(hit.transform.gameObject.name);
             if (hit.transform.tag == "Sivri")
             {
                 Destroy(gameObject, 0.2f);
                 
                         
             }
         }

        if (timeBtwShots <= 0)
        {
            if (Random.Range(0, 100) > 50)
            {
                var asd = Instantiate(Terlik, LF.GetWorldPosition(200f), quaternion.identity);
                asd.GetComponent<Animator>().SetTrigger("onhit");
                Destroy(asd, 0.5f);
                scorescript.soulAmount += 1;
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                var asd = Instantiate(hand, LF.GetWorldPosition(200f), quaternion.identity);
                asd.GetComponent<Animator>().SetTrigger("onhit");
                Destroy(asd, 0.5f);
                scorescript.soulAmount += 1;
                timeBtwShots = startTimeBtwShots;
            }
            
        }
    }


    // Update is called once per frame
        void Update()
        {
            timeBtwShots -= Time.deltaTime;
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    //animat�r buraya eklenecek
                    //  myAnimator.SetTrigger("onhit");
                    Ray ray;
                    RaycastHit hit;
                    ray = Camera.main.ScreenPointToRay(touch.position);
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        if (hit.transform.gameObject.name == ("Sivri"))
                        {
                            Destroy(gameObject, 0.2f);
                            scorescript.soulAmount += 1;
                        }
                        else
                        {
                            var asd = Instantiate(hand, hit.transform);
                            asd.GetComponent<Animator>().SetTrigger("onhit");
                        }
                    }
                }
            }
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                Ray ray;
                RaycastHit hit;
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.gameObject.name == ("AnaKarakter"))

                    {
                        var asd = Instantiate(hand, transform);
                        asd.GetComponent<Animator>().SetTrigger("onhit");
                    }
                }
#endif
            }
        }
    }