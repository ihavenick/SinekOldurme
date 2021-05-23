using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesOynat : StateMachineBehaviour
{
     
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("AnaKarakter").GetComponent<Anakarakter>().RuhCikmasesiOynat();
    }
    
}
