using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public bool hasBall = false;
    public bool canSteal = false;
    public GameObject ball;
    [SerializeField] public Transform ballTarget;
    public int playerNumber;
    public GameObject currentArea;
    public float timeLeft, startTime = 5f;
    TMPro.TextMeshProUGUI timerText;
    public Animation animationClass;

    private void Start()
    {
        if (hasBall) timeLeft = startTime;
        //timerText = GameObject.Find("Timer").GetComponent<TMPro.TextMeshProUGUI>();
        animationClass = transform.GetChild(0).GetComponent<Animation>();
        animationClass.playerNumber = playerNumber;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            Debug.Log("Hit player");
            if (canSteal && player.hasBall)
            {
                canSteal = false;
                GameManager.instance.TransferBall(player, this);
                //TransferBall(player);
                //Disable the area
                currentArea.GetComponent<TransferBallTarget>().SpawnPrefab(playerNumber);
            }
        }
    }

/*    public void TransferBall(Player player)
    {
        //Reparent the ball to the new player
        player.ball.transform.parent = null;
        player.hasBall = false;
        player.ResetTimer();
        hasBall = true;
        ball = player.ball;
        ball.transform.parent = this.transform;
        ball.transform.position = ballTarget.position;
        //Disable the area
    }*/
    public void ResetTimer()
    {
        timeLeft = startTime;
    }

    private void Update()
    {
        if (hasBall)
        {
            timeLeft -= Time.deltaTime;
            //timerText.text = "Timer: " + Mathf.Floor(timeLeft).ToString();
            if (timeLeft < 0)
            {
                if (playerNumber == 1) GameManager.instance.TransferBall(this, GameManager.instance.Player2);
                else GameManager.instance.TransferBall(this, GameManager.instance.Player1);
            }
        }
    }
}
