using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    Animator anim;
     float grip;
     float trigger;

    public enum MyHand
    {
        Left, Right
    }
    public MyHand myHand;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        grip = Convert.ToSingle(Input.GetKey(KeyCode.G));
        trigger = Convert.ToSingle(Input.GetKey(KeyCode.T));
        
       
        anim.SetFloat("Grip", grip);
        //anim.SetFloat("Grip", Input.GetAxis("XRI_"+ myHand +"_Grip"));
        anim.SetFloat("Trigger", trigger);
        //anim.SetFloat("Grip", Input.GetAxis("XRI_" + myHand + "_Trigger"));
    }
}
