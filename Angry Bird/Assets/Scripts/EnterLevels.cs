using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//切关脚本
public class EnterLevels : MonoBehaviour
{
    public int levels;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        Time.timeScale = 1;
        if (levels == 0)
        {
            SceneManager.LoadScene("ChoseLevel");
        }
        if (levels == 1)
        {
            Destroy(GameObject.Find("CarryAudio"));
            SceneManager.LoadScene("LEVEL1");
        }
        if (levels == 2)
        {
            Destroy(GameObject.Find("CarryAudio"));
            SceneManager.LoadScene("LEVEL2");
        }

        if (levels == 3)
        {
            Destroy(GameObject.Find("CarryAudio"));
            SceneManager.LoadScene("Introduction");
        }

        if (levels == 4)
        {
            Destroy(GameObject.Find("CarryAudio"));
            SceneManager.LoadScene("Start");
        }

    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
