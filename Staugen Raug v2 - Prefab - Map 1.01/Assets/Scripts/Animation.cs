using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator animator;
    [SerializeField] KeyCode TurnLeft;
    [SerializeField] KeyCode TurnRight;
    [SerializeField] KeyCode KickFlip;
    [SerializeField] KeyCode _360Flip;
    [SerializeField] KeyCode _180BackSideFlip;
    [SerializeField] KeyCode _180FrontSideFlip;
    [SerializeField] KeyCode SwingReverse;
    [SerializeField] KeyCode SwingForward;

    [SerializeField] GameObject Prefab1;
    [SerializeField] Transform Prefab1Spawn;
    [SerializeField] GameObject Prefab2;
    [SerializeField] Transform Prefab2Spawn;

    [SerializeField] GameObject collider;
    [SerializeField] GameObject collider2;

    public int playerNumber;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    bool isPlaying(string stateName)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    void Update()
    {
        float horizontal = 0;
        horizontal = Input.GetAxis("Horizontal");

        /*        if (Input.GetKey(TurnLeft) && !isPlaying("SwingForward") && !isPlaying("SwingReverse"))
                {
                    if (!animator.GetBool("TurnLeftBlue") && !animator.GetBool("TurnRightBlue")) animator.SetBool("TurnLeftBlue", true);
                }

                if (!Input.GetKey(TurnLeft))
                {
                    animator.SetBool("TurnLeftBlue", false);
                }

                if (horizontal > 0 && !isPlaying("SwingForward") && !isPlaying("SwingReverse"))
                {
                    if (!animator.GetBool("TurnRightBlue") && !animator.GetBool("TurnLeftBlue")) animator.SetBool("TurnRightBlue", true);
                }

                if (!Input.GetKey(TurnRight))
                {
                    animator.SetBool("TurnRightBlue", false);
                }*/
        if (Input.GetKey(TurnLeft) || horizontal < 0)
        {
            if (!animator.GetBool("TurnLeftBlue") && !animator.GetBool("TurnRightBlue")) animator.SetBool("TurnLeftBlue", true);
        }

        if (!Input.GetKey(TurnLeft))
        {
            animator.SetBool("TurnLeftBlue", false);
        }

        if (horizontal > 0 || Input.GetKey(TurnRight))
        {
            if (!animator.GetBool("TurnRightBlue") && !animator.GetBool("TurnLeftBlue")) animator.SetBool("TurnRightBlue", true);
        }

        if (!Input.GetKey(TurnRight))
        {
            animator.SetBool("TurnRightBlue", false);
        }

        if (Input.GetKeyUp(KickFlip))
        {
            animator.SetTrigger("KickFlipBlue");

        }

        if (Input.GetKeyUp(_360Flip))
        {
            animator.SetTrigger("360FlipBlue");
        }

        if (Input.GetKeyUp(_180BackSideFlip))
        {
            animator.SetTrigger("180BackSideBlue");
        }

        if (Input.GetKeyUp(_180FrontSideFlip))
        {
            animator.SetTrigger("180FrontSideBlue");
        }

        if (Input.GetKeyUp(SwingReverse))
        {
            animator.SetTrigger("SwingReverseBlue");
            animator.SetBool("isAttacking", true);
        }
        if (Input.GetKeyUp(SwingForward))
        {
            animator.SetTrigger("SwingForwardBlue");
            animator.SetBool("isAttacking", true);

        }

        JoyStickInputs(playerNumber);
    }

    public void SpawnPrefab(int ID)
    {
        Debug.Log("Spawn Prefab: " + ID);
        GameObject prefab = null;
        Transform position = null;
        if (ID == 1)
        {
            prefab = Prefab1;
            position = Prefab1Spawn;
        } else
        {
            prefab = Prefab2;
            position = Prefab2Spawn;
        }
        GameManager.instance.AddPoints(ID, prefab.GetComponent<PrefabPoints>().points);
        Instantiate(prefab, position.position, Quaternion.identity);
        GameManager.instance.AddPrefab();
    }

    public void SetCollider(int flag)
    {
        collider.SetActive(Convert.ToBoolean(flag));
        if (flag == 0) animator.SetBool("isAttacking", false);
    }
    public void SetCollider2(int flag)
    {
        collider2.SetActive(Convert.ToBoolean(flag));
        if (flag == 0) animator.SetBool("isAttacking", false);
    }

    public string GetAnimation()
    {
        AnimatorClipInfo[] m_CurrentClipInfo = this.animator.GetCurrentAnimatorClipInfo(0);
        return m_CurrentClipInfo[0].clip.name;
    }

    public void JoyStickInputs(int playerNumber)
    {
/*        if (!Input.GetKey(TurnLeft))
        {
            animator.SetBool("TurnLeftBlue", false);
        }

        if (horizontal > 0 && !isPlaying("SwingForward") && !isPlaying("SwingReverse"))
        {
            if (!animator.GetBool("TurnRightBlue") && !animator.GetBool("TurnLeftBlue")) animator.SetBool("TurnRightBlue", true);
        }

        if (!Input.GetKey(TurnRight))
        {
            animator.SetBool("TurnRightBlue", false);
        }*/
        if (playerNumber == 1)
        {
            if (Input.GetButtonUp("P1KickFlip"))
            {
                animator.SetTrigger("KickFlipBlue");

            }

            if (Input.GetButtonUp("P1360"))
            {
                animator.SetTrigger("360FlipBlue");
            }

            if (Input.GetButtonUp("P1180Back"))
            {
                animator.SetTrigger("180BackSideBlue");
            }

            if (Input.GetButtonUp("P1180Front"))
            {
                animator.SetTrigger("180FrontSideBlue");
            }

            if (Input.GetButtonUp("P1SwingReverse"))
            {
                animator.SetTrigger("SwingReverseBlue");
            }
            if (Input.GetButtonUp("P1SwingForward"))
            {
                animator.SetTrigger("SwingForwardBlue");
            }
        }
        else
        {
            if (Input.GetButtonUp("P2KickFlip"))
            {
                animator.SetTrigger("KickFlipBlue");

            }

            if (Input.GetButtonUp("P2360"))
            {
                animator.SetTrigger("360FlipBlue");
            }

            if (Input.GetButtonUp("P2180Back"))
            {
                animator.SetTrigger("180BackSideBlue");
            }

            if (Input.GetButtonUp("P2180Front"))
            {
                animator.SetTrigger("180FrontSideBlue");
            }

            if (Input.GetButtonUp("P2SwingReverse"))
            {
                animator.SetTrigger("SwingReverseBlue");
            }
            if (Input.GetButtonUp("P2SwingForward"))
            {
                animator.SetTrigger("SwingForwardBlue");
            }
        }
 
    }
}
