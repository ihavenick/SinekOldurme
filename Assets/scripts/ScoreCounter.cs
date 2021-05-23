using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private int currentScore;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }
    private void HandleScore()
    {
        scoreText.text = "Score: " + currentScore;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Sivri")
        {
            currentScore++;
            HandleScore();
        }
    }
}
