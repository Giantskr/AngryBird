using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//记录最高分的脚本
public class BestScore : MonoBehaviour
{
    public static int bestScore;
    public Text Score;
    public GameObject NewScore;
    public GameObject OneStar;
    public GameObject TwoStar;
    public GameObject ThreeStar;
    //同时控制星星数量
    public int Level;
    //分别管理两个关卡的最高分

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
        //将最高分从库中读取    
    }

    // Update is called once per frame
    void Update()
    {
        if (bestScore < ScoreText.score)//判定是否获得新的最高分
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
        if (Level == 1)//结束UI里的最高分
        {
            Score.text = "BEST SCORE:" + "\n" + PlayerPrefs.GetInt("BestScore1", 0);
        }
        if (Level == 2)
        {
            Score.text = "BEST SCORE:" + "\n" + PlayerPrefs.GetInt("BestScore2", 0);
        }
        //星星数量判定法则
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
