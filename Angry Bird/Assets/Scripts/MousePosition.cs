using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//实现相机平移
public class MousePosition : MonoBehaviour
{
    public GameObject cameraya;
    Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标
    Vector3 mousePositionOnScreen;
    private float startPositionx;
    public static float deltaX;
    public static float vectory;
    public static float mousePosXLastFrame;
    public static bool start=true;
    private float camera;
    public static float cameraX;
  

    // Start is called before the first frame update
    void Start()
    {
        cameraX = -5;
    }
    private void OnMouseDrag()
    {
        //Debug.Log("yes");
        if (start == true)
        {
            startPositionx = mousePositionInWorld.x; camera = CamerZoom.cameraX; start = false;
        }
       
        deltaX = mousePositionInWorld.x - startPositionx;
        if (cameraX > -5.5&&cameraX<17)
        {
           // Debug.Log(cameraX);
            cameraX = camera - 0.02f * deltaX;
        }
            mousePosXLastFrame = mousePositionInWorld.x;
        
}
     void OnMouseUp()
    {
        //Debug.Log("no");
        start = true;
        vectory = (mousePositionInWorld.x - mousePosXLastFrame) /20;//获得鼠标移动速度
    }
    // Update is called once per frame
    void Update()
    {
        MouseFollow();
        vectory *= 0.95f;//速度衰减
        if ((cameraX < -5.5f&&vectory>0)|| (cameraX > 16.5f && vectory < 0))
        {
            if ((cameraX < -6.5f && vectory > 0) || (cameraX > +17.5 && vectory < 0))
            {
                vectory = 0;
            }
            vectory *=0.4f;
        }
        cameraX = cameraX - vectory;
       
    }
    void MouseFollow()
    {
        //物体跟随鼠标移动
        mousePositionInWorld = Input.mousePosition;
        
    }
}
