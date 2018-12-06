using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreText : MonoBehaviour
{
    public static int score ;
    public Text m_MyText;

    void Start()
    {
        score = 0;
        //Text sets your text to say this message
        m_MyText.text = "Score : "+score;
    }

    void Update()
    {
            m_MyText.text = "Score : " + score;      
    }
}
