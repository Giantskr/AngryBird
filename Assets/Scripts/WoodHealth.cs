using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//长木头的实现，用的动画
public class WoodHealth : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public AudioSource audioSource;
    public AudioClip destroy;
    public int woodHeath=500;
    protected bool destroyed=false;
    protected int beforeDestroy=0;
    // Start is called before the first frame update
    void Start()
    {
         GetComponent<Animator>().SetFloat("Hp",woodHeath);
      
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat("Hp", woodHeath);
        if (woodHeath < 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            beforeDestroy += 1;
            if (destroyed == false)
            {
                audioSource.PlayOneShot(destroy);              
                destroyed = true;   particleSystem.Play();
            }

            if (beforeDestroy > 100)
            {
                ScoreText.score += 500;
                Destroy(gameObject);

            }
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        double damage = Math.Sqrt(collision.relativeVelocity.x * collision.relativeVelocity.x + collision.relativeVelocity.y * collision.relativeVelocity.y);
        //audioSource.PlayOneShot(collisionSound);
        int damagE = (int)damage;
        if(damagE>3)
        {
            audioSource.Play();
            
        }

        woodHeath = woodHeath-50*damagE ;
        // Debug.Log(woodHeath);
    }
}
