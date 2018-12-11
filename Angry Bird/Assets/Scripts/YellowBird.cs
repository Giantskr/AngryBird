using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class YellowBird : BirdMove
{
    public AudioClip Boots;
    private bool isBoost=false;

    // Start is called before the first frame update
    void Start()
    {
       // Time.timeScale = 0.3f;
        animator = BirdSon.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Holder.transform.position = new Vector3(-4.589f, -1.48f, 0);
    }
    private void OnMouseDown()
    {
        DrawLineAndBirdOnTheFoxer();
    }
    private void OnMouseUp()
    {
        Shot();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&state==-1&&isBoost==false)
        {
            BirdSon.GetComponent<Animator>().SetTrigger("Boost");
            Bird.GetComponent<Rigidbody2D>().velocity *= 1.5f;
            audioSource.PlayOneShot(Boots);
            isBoost = true;
            Instantiate(clud);
            clud.transform.position = Bird.transform.position;
        }
        EveryFrame();
    }
}
