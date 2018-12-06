using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterLevels : MonoBehaviour
{
    public int levels;
    public 
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        if (levels == 1)
        {
            SceneManager.LoadScene("LEVEL1");
        }
        if (levels == 2)
        {
            SceneManager.LoadScene("LEVEL2");
        }
        if (levels == 0)
        {
            SceneManager.LoadScene("ChoseLevel");
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
