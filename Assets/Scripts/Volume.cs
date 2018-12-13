using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//场景中的音量开关
public class Volume : MonoBehaviour
{
    public bool isClick=false;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick()

    {
        if (isClick == false)
        {
            AudioListener.volume = 0;
           
        }
        else
        {
            AudioListener.volume = 1;
           
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
