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

    // Start is called before the first frame update
    void Start()
    {
        pipeSpawn = GameObject.FindGameObjectWithTag("PipeSpawn").GetComponent<PipeSpawnScript>();
    }

    [ContextMenu("Increase score")]
    public void addScore(int scoreToAdd) 
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
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
}
