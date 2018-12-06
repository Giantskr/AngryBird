using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class YourScore : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score;
    public Text m_MyText;

    void Start()
    {
        //Text sets your text to say this message
        score = ScoreText.score;
        m_MyText.text = "Your Score: /n/n" + score;
    }

    void Update()
    {
        score = ScoreText.score;
        m_MyText.text = "Your Score: " + "\r\n" + "\r\n" + score;
    }
}
