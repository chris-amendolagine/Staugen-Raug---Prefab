using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferBallSwing : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] Player selfPlayer;

    private void Start()
    {
        selfPlayer = parent.GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other != parent)
        {
            Player player = other.GetComponent<Player>();
            Debug.Log("Hit player");
            if (player.hasBall)
            {
                Debug.Log("Player has ball");
                GameManager.instance.TransferBall(player, selfPlayer);
            }
        }
    }
}
