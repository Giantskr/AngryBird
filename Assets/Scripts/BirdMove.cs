using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;

public class BirdMove : MonoBehaviour
{
    LineRenderer lineRenderer;
    LineRenderer Predictline;
    public ParticleSystem particleSystem;
    public GameObject Bird;
    public GameObject BirdSon;
    public GameObject Holder;
    public GameObject StartPosition;
    public GameObject clud;
    public GameObject MainCamera;
    public GameObject AliveScore;
    public GameObject Collision30;
    public GameObject Collision50;
    public GameObject Collision100;

 

    protected Animator animator;

    protected AudioSource audioSource;
    public AudioClip yell1;
    public AudioClip yell2;
    public AudioClip fly;
    public AudioClip collisionSound;
    public AudioClip shot;
    public AudioClip slingshot;
    public AudioClip Destroyed;

    protected bool isDrag=false;
    Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标
    Vector3 mousePositionOnScreen;
    Vector3 arrowspeed = new Vector3(10,5,0);
    protected float deltaX;
    protected float deltaY;//用于放鼠标与锚点的相对位置关系
    public int state;//用于判断鸟是否上弓
    protected float handerDeltaX;
    protected float handerDeltaY;//用于放托与锚点的相对位置关系
    protected float holderRotation;
    protected float birdDeltaX;
    protected float birdDeltaY;//用于鸟与锚点的相对位置关系
    protected int yellOrJump; 
    protected int betweenTwoAni;
    public int between;
    public int isAliveScore = 0;
    protected bool getReady;
    protected bool Rolled=false;
    protected bool isDestroyAudio = false;
    private bool isAlive = false;

    // Start is called before the first frame update
    void Start()
    {
       // Time.timeScale = 0.3f;调试的痕迹……
        animator = BirdSon.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Holder.transform.position = new Vector3(-4.589f, -1.48f, 0);
        GetComponent<LineRenderer>().enabled = false;

    }
    public void DrawLineAndBirdOnTheFoxer()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;//飞起前锁定x
        if (state == 0&& MainCamera.GetComponent<GameManager>().PigAmount != 0)//如果^(*￣(oo)￣)^都没了，就不让它飞了
        {
            GetComponent<LineRenderer>().enabled = true;
            //画线
            lineRenderer = GetComponent<LineRenderer>();
            Vector3[] vector3s = new Vector3[20];
           for(int i = 0;i<20;i++)//设置点
            {
                vector3s[i] = new Vector3( StartPosition.transform.position.x -  birdDeltaX*i, StartPosition.transform.position.y - birdDeltaY *i-0.025f*i*i, 0);
            }
            lineRenderer.SetPositions(vector3s);
            if (isDrag == false)//拉弹弓响一次
            {
                audioSource.PlayOneShot(slingshot);
                isDrag = true;
            }

            mousePositionOnScreen = Input.mousePosition;
            mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen); //获取鼠标的世界坐标

            if (deltaX * deltaX > 0)//给托位置，旋转
            {
                if (deltaX <= 0)
                {
                    holderRotation = (180 / Mathf.PI) * Mathf.Atan(birdDeltaY / birdDeltaX) - 15;
                }
                else
                {
                    holderRotation = (180 / Mathf.PI) * Mathf.Atan(birdDeltaY / birdDeltaX) - 195;
                }
                Holder.transform.eulerAngles = new Vector3(0, 0, holderRotation);
                Holder.transform.position = new Vector3(handerDeltaX + StartPosition.transform.position.x, handerDeltaY + StartPosition.transform.position.y, -0.1f);
            }

            if (deltaX * deltaX + deltaY * deltaY <= 0.81) //如果鼠标距锚点小等于0.9 ，鼠标位置等于鸟的位置
            {
                if (deltaX < 0 && deltaY < 0 && deltaY / deltaX > 1)
                {
                    if (deltaY > -0.4f)
                    {
                        transform.position = StartPosition.transform.position + new Vector3(deltaY, deltaY, -0.1f);
                    }
                    else
                    {
                        if (deltaX > -0.4)
                        {
                            transform.position = StartPosition.transform.position + new Vector3(-0.4f, deltaY, -0.1f);
                        }
                        else
                        {
                            transform.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, -0.1f);
                        }
                        
                    }
                }
                else
                {
                    if (deltaX > 0 && deltaY < 0 && deltaY / deltaX < -3)
                    {
                        if (deltaY > -0.4f)
                        {
                            transform.position = StartPosition.transform.position + new Vector3(-deltaY, deltaY, -0.1f);
                        }
                        else
                        {
                            if (deltaX < 0.4)
                            {
                                transform.position = StartPosition.transform.position + new Vector3(0.4f, deltaY, -0.1f);
                            }
                            else
                            {
                                transform.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, -0.1f);
                            }
                        }
                    }
                    else
                    {
                        transform.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, -0.1f);
                    }
                }
               //避开弹弓
               // Debug.Log(deltaX +" ,"+ deltaY);
            }
            if (deltaX * deltaX + deltaY * deltaY > 0.81) //如果鼠标距锚点距大于0.9 ，则……
            {
                if ((deltaY /deltaX>2&&deltaX<0&&deltaY<0)||(deltaY/deltaX<-2&&deltaX>0&&deltaY<0))
                {
                    if (deltaX >= 0)
                    {
                        transform.position = StartPosition.transform.position + new Vector3(0.4f, -0.8f, -0.1f);
                    }
                    else
                    {
                        transform.position = StartPosition.transform.position + new Vector3(-0.4f, -0.8f, -0.1f);
                    }
                }
                // float deltax= Math.Abs(deltaX); float deltay = Math.Abs(deltaY);
                double vectory = Math.Sqrt(deltaX * deltaX + deltaY * deltaY); //取得鼠标到锚点向量的模
                float vectory1 = (float)Math.Abs(vectory);//数据类型转换
                float scalei = 0.9f / vectory1;  //Debug.Log(vectory1);//求得0.9与向量的比值
                Bird.GetComponent<Rigidbody2D>().position = new Vector3((scalei * deltaX) +StartPosition.transform.position.x, (scalei * deltaY)+StartPosition.transform.position.y, -0.1f); //实现鸟限制在一定范围的同时 指向鼠标位置
            }
        }
    }
    private void OnMouseDrag()
    {
            DrawLineAndBirdOnTheFoxer();     
    }
    public void Shot()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;//释放z锁定
        if (state == 0)
        {
             if(deltaX * deltaX + deltaY * deltaY < 0.09)//弓都拉了，你也可以不射……
            {
                transform.position = StartPosition.transform.position;
                GetComponent<LineRenderer>().enabled = false;
                isDrag = false;
                Holder.transform.position = StartPosition.transform.position;// new Vector3(-4.589f, -1.48f, 0);
                Holder.transform.eulerAngles = new Vector3(0, 0, 78);
            }
            else
            { 
            if (MainCamera.GetComponent<GameManager>().PigAmount != 0)
            {
                arrowspeed = new Vector3(-15 * birdDeltaX, -15 * birdDeltaY, 0);//设置速度
                Bird.GetComponent<Rigidbody2D>().gravityScale = 0.8f;//给它引力
                Bird.GetComponent<Rigidbody2D>().velocity = arrowspeed;//给它速度
                audioSource.PlayOneShot(fly);
                BirdSon.GetComponent<Animator>().SetTrigger("Fly");
                audioSource.PlayOneShot(shot);
                Holder.transform.position = new Vector3(-4.589f, -1.48f, 0);
                Holder.transform.eulerAngles = new Vector3(0, 0, 78);//让弹弓回去
                GetComponent<LineRenderer>().enabled = false;
                GameManager.states -= 1;//让游戏离结束更近
                state -= 1;//鸟的状态-1
                    if (arrowspeed.x > 0)
                    {
                        MousePosition.vectory = -1;//给相机一个向右的速度

                    }
                GetComponent<TrailRenderer>().enabled = true;
            }
            }
        }
    }
    private void OnMouseUp()
    {
            Shot();
    }

    public void EveryFrame()
    {
        if (isAliveScore==1&&isAlive==false)//加存活分
        {
            AliveScore.SetActive(true);
            ScoreText.score += 10000;
            isAliveScore = 0;
            isAlive = true;
        }
        if (state == 0 && getReady == false)//进入准备状态
        {
            if (Rolled == false)
            {
                animator.SetTrigger("Rolling");
                Rolled = true;
            }
           transform.position = Vector3.MoveTowards(/*BirdSon.*/transform.position, StartPosition.transform.position,6* Time.deltaTime);//debug的痕迹，留着以后总结写进博客hhh
            if (BirdSon.transform.position.x <= -4.5f)
            {
                Bird.GetComponent<PolygonCollider2D>().enabled = true;//现在才开启碰撞体，避免在地面时被先前的鸟撞到
                getReady = true;
            }
                
        }
        betweenTwoAni += 1;//两个动画间切换的计时
        if (state == 0)
        {
            deltaX = mousePositionInWorld.x - StartPosition.transform.position.x;//鼠标距出发点的相对坐标
            deltaY = mousePositionInWorld.y - StartPosition.transform.position.y;
            birdDeltaX = Bird.transform.position.x- StartPosition.transform.position.x;//鸟距出发点的相对坐标
            birdDeltaY = Bird.transform.position.y- StartPosition.transform.position.y;
            double vectory = Math.Sqrt(birdDeltaX * birdDeltaX + birdDeltaY * birdDeltaY); //取得鼠标到锚点向量的模
            float vectory1 = (float)Math.Abs(vectory);//数据类型转换
            handerDeltaX = birdDeltaX + 0.2f * (birdDeltaX / vectory1);//托距出发点的相对坐标
            handerDeltaY = birdDeltaY + 0.2f * (birdDeltaY / vectory1);
        }
        else//进行在地面的动画
        {
            if (betweenTwoAni > between)
            {
                Random rd = new Random();
                yellOrJump = rd.Next(1, 3);
                if (yellOrJump == 1)
                {
                    animator.SetTrigger("Jump");
                }
                if (yellOrJump == 2)
                {
                    animator.SetTrigger("Yell");

                }

                betweenTwoAni = 0;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        EveryFrame();
    }
    void DestroyAudio()
    {
        MainCamera.GetComponent<GameManager>().BirdAmount -= 1; //判定鸟是否全部用完中 减少鸟的数量函数
        audioSource.PlayOneShot(Destroyed);
        particleSystem.Play();
        Instantiate(clud);
        clud.transform.position = Bird.transform.position;
      //  clud.transform.localScale = new Vector3((float)damage * 0.2f, (float)damage * 0.2f, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        double damage = Math.Sqrt(collision.relativeVelocity.x * collision.relativeVelocity.x + collision.relativeVelocity.y * collision.relativeVelocity.y);//获得相对速度的模
        if (damage > 3)
        {
            Instantiate(clud, BirdSon.transform.position, Quaternion.identity);//生成撞击云
            //clud.transform.position = BirdSon.transform.position;Debug.Log(BirdSon.transform.position);
            clud.transform.localScale = new Vector3((float)damage * 0.2f, (float)damage * 0.2f, 1);
            BirdSon.GetComponent<Animator>().SetTrigger("Collision");
            if (!isDestroyAudio)//避免在最初撞击后的0.3秒内出现第二次撞击造成 DestroyAudio 重复执行
            {
                Invoke("DestroyAudio", 5f);
                isDestroyAudio = true;
            }
            
            Destroy(gameObject,5.3f);
            particleSystem.Play();
            if (damage <= 4.5f)//获得撞击分
            {
                Instantiate(Collision30, BirdSon.transform.position, Quaternion.identity);
                ScoreText.score += 30;
            }
            if (damage<=7&& damage > 4.5f)
            {
                Instantiate(Collision50, BirdSon.transform.position, Quaternion.identity);
                ScoreText.score += 50;
            }
            if (damage >7)
            {
                Instantiate(Collision100, BirdSon.transform.position, Quaternion.identity);
                ScoreText.score += 100;
            }
        }
       
    }
}

