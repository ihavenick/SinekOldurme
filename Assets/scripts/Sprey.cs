using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Sprey : MonoBehaviour
{
    
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject SPREY;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwShots -= Time.deltaTime;
    }

    public void KillAll()
    {
        if (timeBtwShots <= 0)
        {
            var asd = Instantiate(SPREY, Vector3.up, quaternion.identity);
            Destroy(asd, 0.6f);


            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Sivri"))
            {
                Destroy(go);



            }
            timeBtwShots = startTimeBtwShots;
        }


        
    }

    
}
