using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int speed = Random.Range(5, 8);
        GetComponent<Rigidbody2D>().velocity = new Vector3(speed, speed+3, 0);
        Destroy(gameObject,3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
