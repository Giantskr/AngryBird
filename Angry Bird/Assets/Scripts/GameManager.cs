using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public AudioSource audioSource;
   public AudioClip GameClear;
   public AudioClip GameFaild;

    public List<GameObject> BirdList;
    //public GameObject BirdOne;
    //public GameObject BirdTwo;
    //public GameObject BirdThree;
    public GameObject EndUI;
    public GameObject Success;
    public GameObject Defeat;

    public static int states=0;
    public static int gameState;//1 playing,2 won,3 fail
    private int timeAfterOver=0;
    private bool hadOver=false;
    public int PigAmount;
    public int BirdAmount;

    // Start is called before the first frame update
    void Start()
    {
        states = 0;
        gameState = 1;
        BirdList[0] .GetComponent<BirdMove>().state = states;//控制各个鸟的状态：是否到弓上
        BirdList[1].GetComponent<BirdMove>().state =states+ 1;
        BirdList[2].GetComponent<BirdMove>().state =states+ 2;
        Time.timeScale = 1;//恢复因为上一场游戏结束而设置成的暂停
        BlueBird.isDivid = false;     //恢复上一场可能的蓝鸟的已经分身
    }
    void GameFailed()
    {
        EndUI.SetActive(true);
        Defeat.SetActive(true);
        Success.SetActive(false);
        audioSource.PlayOneShot(GameFaild);
        Time.timeScale = 0;
    }
    void GameSuccess()
    {
        EndUI.SetActive(true);
        Success.SetActive(true);
        audioSource.PlayOneShot(GameClear);
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(BirdList[0]!=null) BirdList[0].GetComponent<BirdMove>().state = states;
        if (BirdList[1] != null) BirdList[1].GetComponent<BirdMove>().state = states + 1;
        if (BirdList[2] != null) BirdList[2].GetComponent<BirdMove>().state = states + 2;//避免报错hhh
        if (hadOver == false && BirdAmount == 0&&PigAmount!=0)//失败判定
        {
            Invoke("GameFailed", 3);
            hadOver = true;            
        }
        if (gameState == 2)
        {
            if (PigAmount == 0)
            {
                timeAfterOver += 1;
            }
           // Debug.Log(timeAfterOver);
           // Debug.Log(hadOver);
            if (timeAfterOver > 390&&hadOver==false&&PigAmount==0)//成功判定
            {
                if (BirdList[0] != null) BirdList[0].GetComponent<BirdMove>().isAliveScore = 1;
                if (BirdList[1] != null) if (timeAfterOver >400) { BirdList[1].GetComponent<BirdMove>().isAliveScore = 1; }
                if (BirdList[2] != null) if(timeAfterOver>410){ BirdList[2].GetComponent<BirdMove>().isAliveScore = 1; hadOver = true; }
                //回去学一下动态数组
                
                Invoke("GameSuccess", 3);
            }
           
        }
    }
}
