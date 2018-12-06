using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnMouse : MonoBehaviour
{
    private float scaleX;
    private float scaleY;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseOver()
    {
        Debug.Log("oh yeah");
        if (scaleX < 1.2)
        {
            scaleX *= 1.01f;
            scaleY *= 1.01f ;
        }
        gameObject.transform.localScale = new Vector3(scaleX, scaleY,0);
    }
    private void OnMouseExit()
    {
        if (scaleX > 1)
        {
            scaleX *= 0.99f ;
            scaleY *= 0.99f ;
        }
        gameObject.transform.localScale = new Vector3(scaleX, scaleY, 0);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
