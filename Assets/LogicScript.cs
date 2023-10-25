using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public PipeSpawnScript pipeSpawn;
    public PipeMoveScript pipeMove;
    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        pipeSpawn = GameObject.FindGameObjectWithTag("PipeSpawn").GetComponent<PipeSpawnScript>();
        pipeMove = pipeSpawn.pipe.GetComponent<PipeMoveScript>();
        pipeMove.moveSpeed = 8;
    }

    [ContextMenu("Increase score")]
    public void addScore(int scoreToAdd) 
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore != 0 && playerScore % 2 == 0) 
        {
            pipeMove.moveSpeed += 2;
            pipeSpawn.spawnRate -= 0.2F;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        pipeSpawn.canSpawn = false;
        gameOverScreen.SetActive(true);
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseGame();
    }

    public void pauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void quitGame() 
    {
        Application.Quit();
    }
}
