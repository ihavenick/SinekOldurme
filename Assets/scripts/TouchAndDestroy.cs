using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class TouchAndDestroy : MonoBehaviour
{
    public GameObject hand;
    public Texture2D cursor;
    Animator myAnimator;

    // Use this for initialization
    void Start()
    {
        myAnimator = hand.GetComponent<Animator>();
    }

    public void TerlikOlustur(LeanFinger LF)
    {
        var asd =Instantiate(hand, LF.GetWorldPosition(200f),quaternion.identity);
        asd.GetComponent<Animator>().SetTrigger("onhit");
        Destroy(asd, 0.5f);
    }
    
    
    
    
    // Update is called once per frame
    void Update()
    {
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
                    if (hit.transform.gameObject.name == ("HarmonyVideo"))
                    {
                        Destroy(gameObject, 0.2f);
                        scorescript.scoreValue += 1;
                        
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
        if(Input.GetMouseButton(0))
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
