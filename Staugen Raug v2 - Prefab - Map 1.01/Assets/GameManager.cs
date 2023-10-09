using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Player1Object;
    [SerializeField] GameObject Player2Object;
    public Player Player1;
    public Player Player2;
    public static GameManager instance;
    int player1Score, player2Score;
    [SerializeField] TMPro.TextMeshProUGUI player1ScoreText, player2ScoreText, endGame;
    [HideInInspector]
    public int PrefabSpawnCount;
    [SerializeField]
    int maxPrefabs = 14;
    [SerializeField]
    int ballStealPoints = 10;

    [SerializeField] GameObject KickClipPrefab;
    [SerializeField] GameObject _180Prefab;
    [SerializeField] GameObject player1Symbol;
    [SerializeField] GameObject player2Symbol;

    [SerializeField]
    GameObject player1Camera, player2Camera;
    [SerializeField]
    Transform player1CameraPos, player2CameraPos, player1EndPos, player2EndPos;

    [SerializeField]
    private float gameTime = 300;
    private float timer = 0;
    private bool timerOn = false;

    [SerializeField]
    TMPro.TextMeshProUGUI timerText;

    [SerializeField]
    bool showTimer = true;
    [SerializeField]
    float endGameCutsceneTimer = 4f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Player1 = Player1Object.GetComponent<Player>();
        Player2 = Player2Object.GetComponent<Player>();
        player1ScoreText.text = "Score: " + player1Score.ToString();
        player2ScoreText.text = "Score: " + player2Score.ToString();
        timerOn = true;
        if (showTimer)
            timerText.alpha = 1;
        else
            timerText.alpha = 0;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //{
        //    EndGame();
        //}

        //if (timerOn)
        //{
        //    if (timer < gameTime)
        //    {
        //        timer += Time.deltaTime;
        //        timerText.text = "Game Time: " + Mathf.Floor(timer).ToString();
        //    }

        //    else
        //    {
        //        EndGame();
        //        timerOn = false;
        //    }
        //}
    }

    public void TransferBall(Player playerGivingBall, Player playerGettingBall)
    {
        playerGivingBall.ball.transform.parent = null;
        playerGivingBall.hasBall = false;

        playerGettingBall.ResetTimer();
        playerGettingBall.hasBall = true;
        playerGettingBall.ball = playerGivingBall.ball;
        playerGettingBall.ball.transform.parent = playerGettingBall.transform;
        playerGettingBall.ball.transform.position = playerGettingBall.ballTarget.position;

        if (playerGettingBall.playerNumber == 1)
        {
            player1Symbol.SetActive(true);
            StartCoroutine("FadePlayer1");
        } else
        {
            player2Symbol.SetActive(true);
            StartCoroutine("FadePlayer2");
        }
        AddPoints(playerGettingBall.playerNumber, ballStealPoints);
    }

    IEnumerator FadePlayer1()
    {
        Color c = player1Symbol.GetComponent<Image>().color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            player1Symbol.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(.1f);
        }
        player1Symbol.SetActive(false);
    }    
    IEnumerator FadePlayer2()
    {
        Color c = player2Symbol.GetComponent<Image>().color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            player2Symbol.GetComponent<Image>().color = c;
            if (alpha < 0.25)
            {
                player2Symbol.SetActive(false);
                break;
            }
            yield return new WaitForSeconds(.1f);
        }
        
    }

    public void AddPoints(int playerNumber, int points)
    {
        if (playerNumber == 1) player1Score += points;
        else player2Score += points;
        player1ScoreText.text = "Score: " + player1Score.ToString();
        player2ScoreText.text = "Score: " + player2Score.ToString();
    }

    public void AddPrefab()
    {
        PrefabSpawnCount++;
        if (PrefabSpawnCount >= maxPrefabs)
        {
            string result;
            endGame.gameObject.SetActive(true);
            if (player1Score == player2Score)
            {
                result = "Round Over!";
                endGame.text = result;
                return;
            }
            result = player1Score > player2Score ? "Player1 Wins!" : "Player2 Wins!";
            endGame.text = result;
            EndGame();
        }
    }

    private void EndGame()
    {

        player1Camera.transform.position = player1CameraPos.position;
        player1Camera.transform.rotation = player1CameraPos.rotation;        
        
        player2Camera.transform.position = player2CameraPos.position;
        player2Camera.transform.rotation = player2CameraPos.rotation;

        Player1Object.transform.position = player1EndPos.transform.position;
        Player1Object.transform.rotation = player1EndPos.transform.rotation;
        Player1Object.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Player2Object.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        foreach(WheelCollider wheel in Player1Object.GetComponent<SimpleController>().wheels)
        {
            wheel.wheelDampingRate = 100000f;
        }
        foreach (WheelCollider wheel in Player2Object.GetComponent<SimpleController_02>().wheels)
        {
            wheel.wheelDampingRate = 100000f;
        }
        Player2Object.transform.position = player2EndPos.transform.position;
        Player2Object.transform.rotation = player2EndPos.transform.rotation;

        Player1Object.GetComponent<SimpleController>().enabled = false;
        Player1Object.GetComponent<Player>().enabled = false;
        Player1Object.GetComponent<AddForce>().enabled = false;

        Player2Object.GetComponent<SimpleController_02>().enabled = false;
        Player2Object.GetComponent<Player>().enabled = false;
        Player2Object.GetComponent<AddForce_02>().enabled = false;

        StartCoroutine(CutsceneTime());
        //Set animations based on who won here:
        /*
         * if (player1Score > player2Score)
         * {
         *  player1.animator.SetTrigger("Win");
         *  player2.animator.SetTrigger("Lose");
         *  } else if (player1Score < player2Score)
         *  {
         *  player1.animator.SetTrigger("Lose");
         *  player2.animator.SetTrigger("Win");
         *  }
         *  else
         *  {
         *  player1.animator.SetTrigger("Win");
         *  player2.animator.SetTrigger("Win");
         *  }
         *  */
    }

    IEnumerator CutsceneTime()
    {
        yield return new WaitForSeconds(endGameCutsceneTimer);
        SceneManager.LoadScene("Staugen Raug");

    }

}
