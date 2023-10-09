using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_01 : MonoBehaviour

{
    public Transform Spawnpoint;
    public Transform Prefab;
    public Transform ball;
    public Transform myTransform;
    public Transform otherPlayer;
    [HideInInspector] public bool hasBall = false;



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

        private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "Player_01" && hasBall == true)

        {

            Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
        }
    }
}



