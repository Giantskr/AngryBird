using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//选关界面的星星数量
public class ChoseLevelStar : MonoBehaviour
{
    public  int bestScore;
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
        //从数据库读取分数
        if (bestScore == 0)
        {

        }
        if (bestScore>0&&bestScore <= 25000)
        {
            OneStar.SetActive(true);
        }
        if (25000 < bestScore && bestScore <= 30000)
        {
            TwoStar.SetActive(true);
        }
        if (30000 < bestScore)
        {
            ThreeStar.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
