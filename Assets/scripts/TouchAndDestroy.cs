using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TouchAndDestroy : MonoBehaviour
{
    private GameObject harmonyVideo;
    
    // Use this for initialization
    void Start()
    {
        harmonyVideo = GameObject.Find("HarmonyVideo");
    }
    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
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
                        Debug.Log("This object is not the Harmony Video");
                    }
                }
            }
        }
    }
}
