using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour {

    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isTurningRight", true);
            anim.SetBool("isTurningLeft", false);
        }
         else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isTurningLeft", true);
            anim.SetBool("isTurningRight", false);
        }
        else
        {
            anim.SetBool("isTurningRight", false);
            anim.SetBool("isTurningLeft", false);
        }
     //   if((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.)))
	}
}
