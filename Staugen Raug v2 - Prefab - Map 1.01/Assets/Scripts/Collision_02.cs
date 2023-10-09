using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_02 : MonoBehaviour
{
    public Transform Spawnpoint;
    public Transform Prefab;
    public Transform ball;
    public Transform myTransform;
    public Transform otherPlayer;
    [HideInInspector] public bool hasBall = false;


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "Player_02" && hasBall == true)

        {
          Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
        }
    }
}