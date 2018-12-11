using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : BirdMove
{
    public GameObject BlueBird2;
    public GameObject BlueBird3;
    public GameObject BlueBird2Son;
    public GameObject BlueBird3Son;
    private static bool isDivid;
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
            Instantiate(clud, BirdSon.transform.position, Quaternion.identity);
            BlueBird2= Instantiate(Bird, BirdSon.transform.position, Quaternion.identity); BlueBird3 = Instantiate(Bird, BirdSon.transform.position, Quaternion.identity);
            BlueBird2Son = BlueBird2.transform.Find("BIRD_BLUE").gameObject;BlueBird2Son.GetComponent<Animator>().SetTrigger("Fly");
            BlueBird3Son = BlueBird3.transform.Find("BIRD_BLUE").gameObject; BlueBird3Son.GetComponent<Animator>().SetTrigger("Fly");
            BlueBird2.GetComponent<Rigidbody2D>().velocity =  new Vector3(Bird.GetComponent<Rigidbody2D>().velocity.x -1, 0, 0);           
            BlueBird3.GetComponent<Rigidbody2D>().velocity =  new Vector3(Bird.GetComponent<Rigidbody2D>().velocity.x+1, 0, 0);          
            audioSource.PlayOneShot(Destroyed);
            clud.transform.position = Bird.transform.position;
            isDivid = true;
            MainCamera.GetComponent<GameManager>().BirdAmount += 2;//弥补增加两个鸟造成的鸟个数判定错误
        }
    }
}
