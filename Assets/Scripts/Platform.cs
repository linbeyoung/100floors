using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // 这里要改变所有物体的position,所以是三维
    Vector3 movement;
    GameObject topLine;
    public float speed;
    // Start is called before the first frame update

    void Start()
    {
        movement.y = speed;
        topLine = GameObject.Find("TopLine");

    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        transform.position += movement * Time.deltaTime;
        movement += new Vector3(0, 0, 1);

        if (transform.position.y >= topLine.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
