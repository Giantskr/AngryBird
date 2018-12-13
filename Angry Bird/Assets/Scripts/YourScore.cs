using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI计分板
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
        if (score == 0)
        {

        }
        if (score>0&&score <= 25000)
        {
            OneStar.SetActive(true);
        }
        if(2500<score&&score<=30000)
        {
            TwoStar.SetActive(true);
        }
        if (30000 < score )
        {
            ThreeStar.SetActive(true);
        }
    }
}
