using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerZoom : MonoBehaviour
{
    public GameObject BackGroundFar;
    public GameObject BackGroundMid;
    private float zoom;
    private float zoomTime = 0;
    private bool startZoomIn = false;
    private bool startZoomOut = false;
    private float cameraY;
    public static float cameraX;
    public AudioSource audioSource;
    private int timeAfterStart=0;
    //相机缩放
    // Start is called before the first frame update
    void Start()
    {
        //初始镜头大小
        zoom = 4f;
        Camera.main.orthographicSize = 4f;
        audioSource.Play();
        cameraX = 15;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeAfterStart < 101)
        {
            cameraX = cameraX - 0.2f ;
            timeAfterStart += 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            startZoomIn = true;//开始缩放
        }
        if (startZoomIn == true && Camera.main.orthographicSize <= 5)
        {
            zoomTime += 1;
            zoom = zoom + 0.003f * zoomTime; 
        }
        if (zoomTime > 20 || Camera.main.orthographicSize > 5 || Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            zoomTime = 0;
            startZoomIn = false;//停止缩放
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            startZoomOut = true;
        }
        if (startZoomOut == true && Camera.main.orthographicSize > 2.5)
        {
            zoomTime += 1;
            zoom = zoom - 0.003f * zoomTime;
        }
        if (zoomTime > 20 || Camera.main.orthographicSize < 2.5 || Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            zoomTime = 0;
            startZoomOut = false;
        }
        cameraY = 0.66f * zoom - 2.9f;//改变y坐标
        //cameraX = 5 - zoom;
        if (timeAfterStart > 100)
        {
            cameraX = MousePosition.cameraX;
        }
        //改变x
        GetComponent<Transform>().position = new Vector3(0.3f * cameraX, cameraY, -10f);
        BackGroundFar.GetComponent<Transform>().position = new Vector3(cameraX * 0.1f, -1.4f, 0.4f);
        BackGroundMid.GetComponent<Transform>().position = new Vector3(2 + cameraX * 0.15f, -1.23f, -0.1053005f);//让背景移动 获得仿3d效果
        Camera.main.orthographicSize = zoom;

    }
}
    