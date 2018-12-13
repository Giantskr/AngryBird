using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//退游戏脚本
public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
