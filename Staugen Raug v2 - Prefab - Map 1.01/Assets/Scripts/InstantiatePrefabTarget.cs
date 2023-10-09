using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabTarget : MonoBehaviour
{
    [Header("Player 1 Prefabs and Locations")]
    [SerializeField] GameObject player1Easy;
    [SerializeField] Transform player1EasySpawn;

    [SerializeField] GameObject player1Medium;
    [SerializeField] Transform player1MediumSpawn;

    [SerializeField] GameObject player1Hard;
    [SerializeField] Transform player1HardSpawn;

    [Header("Player 2 Prefabs and Locations")]
    [SerializeField] GameObject player2Easy;
    [SerializeField] Transform player2EasySpawn;

    [SerializeField] GameObject player2Medium;
    [SerializeField] Transform player2MediumSpawn;

    [SerializeField] GameObject player2Hard;
    [SerializeField] Transform player2HardSpawn;

    private float timer = 0f, maxTime = 2f;
    private bool timerOn;
    private Vector2 prefabSize = new Vector2(1, 1);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player.hasBall && !timerOn)
            {
                //If the player has the ball, instantiate the prefab at the transform dragged into the area's inspector,
                //and disable this area
                GameObject prefabToSpawn = player1Easy;
                prefabToSpawn = player.playerNumber < 2 ? player1Easy : player2Easy;
                Transform PrefabSpawn = player.playerNumber < 2 ? player1EasySpawn : player2EasySpawn;
                switch (player.animationClass.GetAnimation())
                {
                    case "KickFlip":
                        prefabToSpawn = player.playerNumber < 2 ? player1Medium : player2Medium;
                        PrefabSpawn = player.playerNumber < 2 ? player1MediumSpawn : player2MediumSpawn;
                        break;
                    case "360Flip":
                        prefabToSpawn = player.playerNumber < 2 ? player1Medium : player2Medium;
                        PrefabSpawn = player.playerNumber < 2 ? player1MediumSpawn : player2MediumSpawn;
                        break; 
                    case "180BackSideFlip":
                        prefabToSpawn = player.playerNumber < 2 ? player1Hard : player2Hard;
                        PrefabSpawn = player.playerNumber < 2 ? player1HardSpawn : player2HardSpawn;
                        break;
                    case "180FrontSideFlip":
                        prefabToSpawn = player.playerNumber < 2 ? player1Hard : player2Hard;
                        PrefabSpawn = player.playerNumber < 2 ? player1HardSpawn : player2HardSpawn;
                        break;
                    default:
                        break;
                }

                Instantiate(prefabToSpawn, PrefabSpawn.position, PrefabSpawn.rotation);
                player.ResetTimer();
                GameManager.instance.AddPoints(player.playerNumber, prefabToSpawn.GetComponent<PrefabPoints>().points);
                GameManager.instance.AddPrefab();
                timer = 0;
                timerOn = true;
                this.gameObject.SetActive(false);
            }
        }
    }

    //private void Update()
    //{
    //    if (timerOn)
    //    {
    //        if (timer < maxTime)
    //            timer += Time.deltaTime;
    //        else
    //            timerOn = false;
    //    }
    //}
}
