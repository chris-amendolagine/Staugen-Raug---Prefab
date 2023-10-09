using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject Prefab1;
    [SerializeField] Transform Prefab1Spawn;
    [SerializeField] GameObject Prefab2;
    [SerializeField] Transform Prefab2Spawn;    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("TurnLeftBlue", true);
        }

        if (!Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("TurnLeftBlue", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("TurnRightBlue", true);
        }

        if (!Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("TurnRightBlue", false);
        }
        if(Input.GetKey(KeyCode.Y))
        {
            animator.SetTrigger("KickFlipBlue");

        }        

        if(Input.GetKey(KeyCode.J))
        {
            animator.SetTrigger("360FlipBlue");
        }
    
        if(Input.GetKey(KeyCode.G))
        {
            animator.SetTrigger("180BackSideBlue");
        }
        
        if(Input.GetKey(KeyCode.H))
        {
            animator.SetTrigger("180FrontSideBlue");
    }
    
        if(Input.GetKey(KeyCode.RightCommand))
    {
            animator.SetTrigger("SwingReverseBlue");
    }
        if(Input.GetKey(KeyCode.RightShift))
        {
            animator.SetTrigger("SwingForwardBlue");
        }



        }
        }
        
        
