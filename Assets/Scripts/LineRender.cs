using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{   
    LineRenderer line;
    public Transform startPoint;
    public Transform endPoint;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, startPoint.position);  // 设置序号 + 相应的点
        line.SetPosition(1, endPoint.position);  // 设置序号 + 相应的点  | 序号来自于linerenderer的组件
    }
}
