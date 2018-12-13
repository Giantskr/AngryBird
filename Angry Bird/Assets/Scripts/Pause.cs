using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//游戏暂停
public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick()

    {
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
