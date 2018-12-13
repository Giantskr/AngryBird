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
            Instantiate(clud, BirdSon.transform.position, Quaternion.identity);
        }
        EveryFrame();
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
            isBoost = true;
        }

    }
}
