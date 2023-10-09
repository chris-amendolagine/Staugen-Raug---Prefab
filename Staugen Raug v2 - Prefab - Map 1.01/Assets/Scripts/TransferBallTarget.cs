using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferBallTarget : MonoBehaviour
{

    [SerializeField] GameObject player1Prefab;
    [SerializeField] GameObject player2Prefab;
    [SerializeField] Transform examplePrefabSpawn;

    private void OnTriggerEnter(Collider other)
    {
        //If an object with the player tag enters this area and does not have the ball, it can now steal the ball from any players.
        //If you use tags differently in your project, instead of comparing tag use:

        // if (other.GetComponent<Player>() != null)
        //Using tags performs better however.

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (!player.hasBall) player.canSteal = true; //Can alternatively name this "inArea" or something equivalent.
            player.currentArea = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //If the player exits the area, it can no longer steal a ball.
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.canSteal = false;
        }
    }


    public void SpawnPrefab(int playerNumber)
    {
        GameObject prefabToSpawn = player1Prefab;
        if (playerNumber == 2) prefabToSpawn = player2Prefab;
        GameManager.instance.AddPoints(playerNumber, prefabToSpawn.GetComponent<PrefabPoints>().points);
        Instantiate(prefabToSpawn, examplePrefabSpawn.position, Quaternion.identity);
        GameManager.instance.AddPrefab();
        this.gameObject.SetActive(false);
    }

}
