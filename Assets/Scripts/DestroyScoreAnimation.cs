using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//一个广泛用于各个文字动画的脚本
public class DestroyScoreAnimation : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
