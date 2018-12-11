using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreText : MonoBehaviour
{
    public static int score ;
    public Text m_MyText;
    public int Level;
    void Start()
    {
        score = 0;
        //Text sets your text to say this message
        if (Level == 1)
        {
            m_MyText.text = "Best Score :" + PlayerPrefs.GetInt("BestScore1", 0) + "\n" + "Score :       " + score;
        }
        if (Level == 2)
        {
            m_MyText.text = "Best Score :" + PlayerPrefs.GetInt("BestScore2", 0) + "\n" + "Score :       " + score;
        }
    }

    void Update()
    {
        if (Level == 1)
        {
            m_MyText.text = "Best Score :" + PlayerPrefs.GetInt("BestScore1", 0) + "\n" + "Score :       " + score;
        }
        if (Level == 2)
        {
            m_MyText.text = "Best Score :" + PlayerPrefs.GetInt("BestScore2", 0) + "\n" + "Score :       " + score;
        }
    }
}
