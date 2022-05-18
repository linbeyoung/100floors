using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    public List<GameObject> platforms = new List<GameObject>();  // 可以填数字

    public float spawnTime;
    private float countTime;  // 计算生成时间
    private Vector3 spawnPosition;  // 生成的位置
    int spikenum = 0;

    // Start is called before the first frame update
    // Update is called once per frame

    void Update()
    {
        SpawnPlatform();
    }

    public void SpawnPlatform()
    {
        countTime += Time.deltaTime;
        spawnPosition = transform.position;  // 生成的物体就是在sp的位置上生成的
        // 但是要看下左右的限制分别在哪
        spawnPosition.x = Random.Range(-3.2f, 3.2f);

        if (countTime >= spawnTime)
        {
            // int index = Random.Range(0, platforms.Count);
            // Instantiate(platforms[index], spawnPosition, Quaternion.identity);
            CreatePlatform();
            countTime = 0;
        }
    }

    public void CreatePlatform()  // 随机创建平台函数
    {
        int index = Random.Range(0, platforms.Count);
        
        // 避免同时生成两个spikeball
        if (index == 4)
        if (spikenum >= 1)
        {
            index = Random.Range(0, platforms.Count - 1);
            spikenum = 0;
        }
        else{
            spikenum++;
        }

        GameObject newPlatform = Instantiate(platforms[index], spawnPosition, Quaternion.identity);  // 角度不变
        
        //如果希望都处在startline里面
        
        newPlatform.transform.SetParent(this.gameObject.transform);
    }
}
