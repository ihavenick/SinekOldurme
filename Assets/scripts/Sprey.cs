using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprey : MonoBehaviour
{

    public GameObject sprey;
    private bool cooldown = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillAll()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Sivri"))
        {
            Destroy(go);

            

        }
        


        /* var asd = Instantiate(sprey, transform);
         asd.GetComponent<Animator>().SetTrigger("sprey");*/
    }

    
}
