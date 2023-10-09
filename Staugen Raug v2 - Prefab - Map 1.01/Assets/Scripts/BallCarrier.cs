using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallCarrier : MonoBehaviour
{
    public Transform ball;
    public Transform myTransform;
    public Transform otherPlayer;
    [HideInInspector] public bool hasBall = false;
    bool waiting = false;
    void Start()
    {

        if (myTransform.gameObject.name == "Player_01")
        {
            ball.transform.SetParent(myTransform);
            hasBall = true;
        }
        if (myTransform.gameObject.name == "Player_02")
        {
            hasBall = false;
        }

    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.transform == otherPlayer && hasBall && !waiting)
        {
            ball.SetParent(otherPlayer);
            hasBall = false;
            BallCarrier ballCarrier = otherPlayer.GetComponent<BallCarrier>();
            ballCarrier.hasBall = true;
            StartCoroutine(ballCarrier.Wait());
            StartCoroutine(Wait());
        }
    }


    IEnumerator Wait()
    {

        waiting = true;
        yield return new WaitForSeconds(1f);
        waiting = false;

    }

}

