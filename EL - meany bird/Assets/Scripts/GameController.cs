using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //game over canvas that is used for the game
    [Header("Game Over UI Object for displaying Game Over Screen")]
    public GameObject gameOverCanvas;
    //score canvas that is used for the game
    [Header("Score UI Object for displaying Score")]
    public GameObject scoreCanvas;
    //spawner object that is used for the game
    [Header("Spawner Object for spawning objects in game")]
    public GameObject spawner;


    // Start is called before the first frame update
    void Start()
    {

        //speed for the game is at a playing state
        Time.timeScale = 1;
        //score in visible
        scoreCanvas.SetActive(true);
        //game over UI is invisible
        gameOverCanvas.SetActive(false);
        //the spawner is shown in the game
        spawner.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GameOver()
    {

        //game over UI is visible
        gameOverCanvas.SetActive(true);
        //the spawner is now invisible in the game
        spawner.SetActive(false);
        //the speed for the game is now at a stopping state
        Time.timeScale = 0;
    }
}
