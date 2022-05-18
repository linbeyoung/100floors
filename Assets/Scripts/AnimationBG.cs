using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBG : MonoBehaviour
{
    // Start is called before the first frame update
    Material material;  // 属性是材质球
    Vector2 movement;

    // 需要有个速度可以调节y移动
    public Vector2 speed; 
    void Start()
    {
        material = GetComponent<Renderer>().material;  // GetComponent内并不是Material,是通过渲染调整我们的材质才获得图片上的渲染
    }

    // Update is called once per frame
    void Update()
    {   
        movement += speed * Time.deltaTime;  // 每帧移动
        // 主要材质的贴图的offset
        material.mainTextureOffset = movement;
           
    }
}
