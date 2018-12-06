using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public int pigHeath = 100;
    public GameObject smoke;
    public GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pigHeath <= 1)
        {
            ScoreText.score += 5000;
            Instantiate(smoke, transform.position, Quaternion.identity);
            GameObject go = Instantiate(score, transform.position+new Vector3(0,1,0), Quaternion.identity);
            GameManager.gameState = 2;
            //Debug.Log(GameManager.gameState);
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        double damage = Math.Sqrt(collision.relativeVelocity.x * collision.relativeVelocity.x + collision.relativeVelocity.y * collision.relativeVelocity.y);
        pigHeath -= (int)damage*20;
        
    }
}
