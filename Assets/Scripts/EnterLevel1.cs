using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//第一个开场动画结束后进入第一关
public class EnterLevel1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadSceneOne", 15.6f);//等待动画、bgm放完
    }
    void LoadSceneOne()
    {
        SceneManager.LoadScene("LEVEL1");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("LEVEL1");
        }
    }
}
