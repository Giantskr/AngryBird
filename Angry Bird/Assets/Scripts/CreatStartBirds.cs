using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatStartBirds : MonoBehaviour
{
    public GameObject BlueBird;
    public GameObject RedBird;
    public GameObject YellowBird;
    private GameObject Bird;
    private int WhichBird; //0 red，1 blue， 2 yellow
    private int delta=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {

        delta += 1;
        if (delta > 50)
        {
            WhichBird = Random.Range(0, 3);
            switch (WhichBird)
            {
                case 0: Bird = BlueBird;break;
                case 1: Bird = RedBird; break;
                case 2: Bird = YellowBird; break;
            }
            int X = Random.Range(-20,10);
            Instantiate(Bird, new Vector3(X,-5,0), Quaternion.identity);
            delta = 0;
        }
    }
        
}
