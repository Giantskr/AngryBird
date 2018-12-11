using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public static int bestScore;
    public Text Score;
    public GameObject NewScore;

    public GameObject OneStar;
    public GameObject TwoStar;
    public GameObject ThreeStar;

    public int Level;

    // Start is called before the first frame update
    void Start()
    {
        if (Level == 1)
        {
            bestScore = PlayerPrefs.GetInt("BestScore1", 0);
        }
        if (Level == 2)
        {
            bestScore = PlayerPrefs.GetInt("BestScore2", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bestScore < ScoreText.score)
        {
            bestScore = ScoreText.score;
            NewScore.SetActive(true);
            if (Level == 1)
            {
                PlayerPrefs.SetInt("BestScore1", bestScore);
            }
            if (Level == 2)
            {
                PlayerPrefs.SetInt("BestScore2", bestScore);
            }
        }
        if (Level == 1)
        {
            Score.text = "BEST SCORE:" + "\n" + PlayerPrefs.GetInt("BestScore1", 0);
        }
        if (Level == 2)
        {
            Score.text = "BEST SCORE:" + "\n" + PlayerPrefs.GetInt("BestScore2", 0);
        }

        if (bestScore <= 5000)
        {
            OneStar.SetActive(true);
        }
        if (5000 < bestScore && bestScore <= 10000)
        {
            TwoStar.SetActive(true);
        }
        if (10000 < bestScore)
        {
            ThreeStar.SetActive(true);
        }

    }
}
