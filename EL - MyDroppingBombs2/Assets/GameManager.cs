using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private spawner spawner;
    public GameObject title;
    private Vector2 screenBounds;
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;
    public GameObject splash;
    public GameObject ScoreSystem;
    public Text scoreText;
    public int pointsWorth = 1;
    private int score;

    private bool smokeCleared = true;

    private int highScore = 0;
    public Text highScoreText;
    private bool beatHighScore;
    // Start is called before the first frame update

    void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = playerPrefab;
        scoreText.enabled = false;
        highScoreText.enabled = false;
    }

    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(false);

        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "HighScore" + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown && smokeCleared)
            {
                smokeCleared = false;
                ResetGame();
            }
        } else
        {
            if (!player)
            {
                OnPlayerKilled();
            }
        }


        var nextBomb = GameObject.FindGameObjectsWithTag("Bomb");

        foreach(GameObject bombObject in nextBomb)
        {
            if (!gameStarted)
            {
                Destroy(bombObject);
            } else if (bombObject.transform.position.y < (-screenBounds.y) - 12 || !gameStarted)
            {
                ScoreSystem.GetComponent<Score>().AddScore(pointsWorth);
                Destroy(bombObject);
            }
        }

        if (!gameStarted)
        {
            var textColor = "#323232";

            if (beatHighScore)
            {
                textColor = "#F00";
            }

            highScoreText.text = "<color=" + textColor + ">High Score:" + highScore.ToString() + "</color>";
        }
        else
        {
            highScoreText.text = "";
        }
    }

    void ResetGame()
    {
        spawner.active = true;
        title.SetActive(false);
        splash.SetActive(false);
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
        gameStarted = true;

        scoreText.enabled = true;
        ScoreSystem.GetComponent<Score>().score = 0;
        ScoreSystem.GetComponent<Score>().Start();

        beatHighScore = false;
        highScoreText.enabled = true;
    }

    void OnPlayerKilled()
    {
        spawner.active = false;
        gameStarted = false;

        Invoke("SplashScreen", 2f);

        score = ScoreSystem.GetComponent<Score>().score;

        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            beatHighScore = true;
            highScoreText.text = "High Score:" + highScore.ToString();
        }
    }

    void SplashScreen()
    {
        smokeCleared = true;
        splash.SetActive(true);
    }
}
