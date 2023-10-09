using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController02: MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("TurnLeftRed", true);
        }

        if (!Input.GetKey(KeyCode.D))
        {
            animator.SetBool("TurnLeftRed", false);
        }
       
        if (Input.GetKey(KeyCode.G))
        {
            animator.SetBool("TurnRightRed", true);
        }

        if (!Input.GetKey(KeyCode.G))
        {
            animator.SetBool("TurnRightRed", false);
        }
        if(Input.GetKey(KeyCode.O))
        {
            animator.SetTrigger("KickFlipRed");

        }        

        if(Input.GetKey(KeyCode.L))
        {
            animator.SetTrigger("360FlipRed");
        }
     
        if(Input.GetKey(KeyCode.K))
        {
            animator.SetTrigger("180BackSideRed");
        }
      if(Input.GetKey(KeyCode.M))
        {
            animator.SetTrigger("180FrontSideRed");
    }
     if(Input.GetKey(KeyCode.A))
    {
            animator.SetTrigger("SwingReverseRed");
    }
        if(Input.GetKey(KeyCode.P))
        {
            animator.SetTrigger("SwingForwardRed");
        }



        
    }
    }  
