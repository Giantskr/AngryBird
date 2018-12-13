using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//最初用在中等长度的wood，后来石头、玻璃也用了
public class MidWood : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public AudioSource audioSource;
    public AudioClip damage;
    public AudioClip destroy;

    public int woodHeath = 500;
    public Sprite hp100;
    public Sprite hp75;
    public Sprite hp50;
    public Sprite hp25;

    private bool destroyed = false;
    private bool isdamaged = false;//用于damage音效
    private int beforeDestroy = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (woodHeath/100)//根据血量改贴图
        {
            case 5: GetComponent<SpriteRenderer>().sprite = hp100;break;
            case 3: GetComponent<SpriteRenderer>().sprite = hp75; break;
            case 2: GetComponent<SpriteRenderer>().sprite = hp50;
                if (isdamaged == false) { audioSource.PlayOneShot(damage);isdamaged = true; }
                ; break;
            case 0: GetComponent<SpriteRenderer>().sprite = hp25; break;
        }
        if (woodHeath < 0)//木头摧毁
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = Color.clear;
            beforeDestroy += 1;
            if (destroyed == false)
            {
                audioSource.PlayOneShot(destroy);
                destroyed = true; GetComponent<ParticleSystem>().Play();
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
        double damage = System.Math.Sqrt(collision.relativeVelocity.x * collision.relativeVelocity.x + collision.relativeVelocity.y * collision.relativeVelocity.y);
        int damagE = (int)damage;
        if (damagE > 5)
        {
            audioSource.Play();
        }
        woodHeath = woodHeath - 100 * damagE;
       //Debug.Log(woodHeath);
    }
}
