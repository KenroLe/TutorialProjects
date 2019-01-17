using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    private int score;
    private bool gameOver;
    private bool restart;

    public GameObject hazard;
    public Vector3 SpawnValues;
    public int hazardCount;

    public float spawnWait;
    public float startWait;
    public float waveWait;


    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.touchCount > 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
                Quaternion spawnRot = Quaternion.identity;
                Instantiate(hazard, spawnPos, spawnRot);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "touch to restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
