using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    //游戏继续实现
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick()

    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
