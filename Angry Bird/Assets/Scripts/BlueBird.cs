using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BlueBird : BirdMove
{
    public GameObject BlueBird2;
    public GameObject BlueBird3;
    public GameObject BlueBird2Son;
    public GameObject BlueBird3Son;
    public static bool isDivid;
    // Start is called before the first frame update
    void Start()
    {
        animator = BirdSon.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Holder.transform.position = new Vector3(-4.589f, -1.48f, 0);
    }

    // Update is called once per frame
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
        EveryFrame();
        if (Input.GetMouseButtonDown(0) && state == -1 && isDivid == false)
        {
            Instantiate(clud, BirdSon.transform.position  ,Quaternion.identity);
            BlueBird2= Instantiate(Bird, BirdSon.transform.position+new Vector3(0.4f, 0, 0), Quaternion.identity);
            BlueBird3 = Instantiate(Bird, BirdSon.transform.position + new Vector3(-0.4f, 0, 0), Quaternion.identity);//生成两个新鸟
            BlueBird2Son = BlueBird2.transform.Find("BIRD_BLUE").gameObject;BlueBird2Son.GetComponent<Animator>().SetTrigger("Fly");
            BlueBird3Son = BlueBird3.transform.Find("BIRD_BLUE").gameObject; BlueBird3Son.GetComponent<Animator>().SetTrigger("Fly");
            BlueBird2.GetComponent<Rigidbody2D>().velocity =  new Vector3(Bird.GetComponent<Rigidbody2D>().velocity.x - 0.3f * Bird.GetComponent<Rigidbody2D>().velocity.y, Bird.GetComponent<Rigidbody2D>().velocity.y - 0.3f * Bird.GetComponent<Rigidbody2D>().velocity.x, 0); //在原来鸟的速度的基础上加上一个法向的速度          
            BlueBird3.GetComponent<Rigidbody2D>().velocity =  new Vector3(Bird.GetComponent<Rigidbody2D>().velocity.x+0.3f*Bird.GetComponent<Rigidbody2D>().velocity.y, Bird.GetComponent<Rigidbody2D>().velocity.y+ 0.3f *Bird.GetComponent<Rigidbody2D>().velocity.x, 0);          
            audioSource.PlayOneShot(Destroyed);
            Instantiate(clud, BirdSon.transform.position, Quaternion.identity);
            isDivid = true;
            MainCamera.GetComponent<GameManager>().BirdAmount += 2;//弥补增加两个鸟造成的鸟个数判定错误
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        double damage = Math.Sqrt(collision.relativeVelocity.x * collision.relativeVelocity.x + collision.relativeVelocity.y * collision.relativeVelocity.y);
        if (damage > 3)
        {
            Instantiate(clud, BirdSon.transform.position, Quaternion.identity);
            //clud.transform.position = BirdSon.transform.position;Debug.Log(BirdSon.transform.position);
            clud.transform.localScale = new Vector3((float)damage * 0.2f, (float)damage * 0.2f, 1);
            BirdSon.GetComponent<Animator>().SetTrigger("Collision");
            if (!isDestroyAudio)//避免在最初撞击后的0.3秒内出现第二次撞击造成 DestroyAudio 重复执行
            {
                Invoke("DestroyAudio", 5f);
                isDestroyAudio = true;
            }

            Destroy(gameObject, 5.3f);
            particleSystem.Play();
            if (damage <= 4.5f)
            {
                Instantiate(Collision30, BirdSon.transform.position, Quaternion.identity);
                ScoreText.score += 30;
            }
            if (damage <= 7 && damage > 4.5f)
            {
                Instantiate(Collision50, BirdSon.transform.position, Quaternion.identity);
                ScoreText.score += 50;
            }
            if (damage > 7)
            {
                Instantiate(Collision100, BirdSon.transform.position, Quaternion.identity);
                ScoreText.score += 100;
            }
            isDivid = true;
        }
    }
}
