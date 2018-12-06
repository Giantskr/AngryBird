﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public AudioSource audioSource;
   public AudioClip GameClear;
   public AudioClip GameFaild;
    public GameObject BirdOne;
    public GameObject BirdTwo;
    public GameObject BirdThree;
    public GameObject EndUI;
    public static int states=0;
    public static int gameState;//1 playing,2 won,3 fail
    private int timeAfterOver=0;
    private bool hadOver=false;

    // Start is called before the first frame update
    void Start()
    {
        states = 0;
        gameState = 1;
        BirdOne.GetComponent<BirdMove>().state = states;
        BirdTwo.GetComponent<BirdMove>().state =states+ 1;
        BirdThree.GetComponent<BirdMove>().state =states+ 2;

    }

    // Update is called once per frame
    void Update()
    {
        if(BirdOne!=null)BirdOne.GetComponent<BirdMove>().state = states;
        if (BirdTwo != null) BirdTwo.GetComponent<BirdMove>().state = states + 1;
        if (BirdThree != null) BirdThree.GetComponent<BirdMove>().state = states + 2;
        if (gameState == 2)
        {
            timeAfterOver += 1;
           // Debug.Log(timeAfterOver);
           // Debug.Log(hadOver);
            if (timeAfterOver > 200&&hadOver==false)
            {
                EndUI.SetActive(true);
                audioSource.PlayOneShot(GameClear);
                hadOver = true;
            }
        }
    }
}
