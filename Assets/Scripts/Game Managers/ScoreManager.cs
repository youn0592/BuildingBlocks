using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public GameObject ScoreHud;
    public GameObject gameOverScore;
    public GameObject highScoreHud;
    public GameObject highScoreGOHud;
    Text scoreText;
    Text gameOverText;
    Text highScoreText;
    Text highScoreGOText;
    int scoreNum = 0;

    GlobalParms parms;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = ScoreHud.GetComponent<Text>();
        gameOverText = gameOverScore.GetComponent<Text>();
        highScoreText = highScoreHud.GetComponent<Text>();
        highScoreGOText = highScoreGOHud.GetComponent<Text>();



        parms = GetComponent<GlobalParms>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreHud.activeInHierarchy || gameOverScore.activeInHierarchy)
        {
            scoreText.text = scoreNum.ToString();
            gameOverText.text = scoreNum.ToString();

            if (scoreNum >= parms.HighScore)
            {
                parms.HighScore = scoreNum;
                highScoreText.text = parms.HighScore.ToString();
                highScoreGOText.text = parms.HighScore.ToString();
            }
        }

    }
    public void UpScore()
    {
        scoreNum++;
    }
    public void DownScore()
    {
        scoreNum--;
    }

    public void SetScore(int num)
    {
        scoreNum = num;
    }

    public int GetScore()
    {
        return scoreNum;
    }
}
