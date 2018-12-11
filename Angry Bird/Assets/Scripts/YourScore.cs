using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class YourScore : MonoBehaviour
{
    public GameObject OneStar;
    public GameObject TwoStar;
    public GameObject ThreeStar;
    // Start is called before the first frame update
    public static int score;
    public Text m_MyText;

    void Start()
    {
        //Text sets your text to say this message
        score = ScoreText.score;
        m_MyText.text = "Your Score: " + "\r\n" + "\r\n" + score;
    }

    void Update()
    {
        score = ScoreText.score;
        m_MyText.text = "Your Score: " + "\r\n" + "\r\n" + score;
        if (score <= 5000)
        {
            OneStar.SetActive(true);
        }
        if(5000<score&&score<=10000)
        {
            TwoStar.SetActive(true);
        }
        if (10000 < score )
        {
            ThreeStar.SetActive(true);
        }
    }
}
