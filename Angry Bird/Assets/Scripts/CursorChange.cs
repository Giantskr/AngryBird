using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//实现鼠标
public class CursorChange : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D cursorTexture2;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        DontDestroyOnLoad(transform.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }
    }
}
