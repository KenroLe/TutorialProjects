using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText;

    private int score = 0;

    private void LateUpdate()
    {
        scoreText.text = "Score: "+ score;
    }

    public void AddScore()
    {
        score++;
    }
}
