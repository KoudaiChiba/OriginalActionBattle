using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // キューブのPrefab
    public GameObject enemy1Prefab;

    public GameObject enemy2Prefab;

    // 時間計測用の変数
    private float delta = 0;

    // キューブの生成間隔
    private float span = 3.0f;

    int ratio = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        // span秒以上の時間が経過したかを調べる
        if (this.delta > this.span)
        {
            this.delta = 0;

            GameObject enemy;

            int dice = Random.Range(1, 11);

            if (dice <= this.ratio)
            {
                enemy = Instantiate(enemy1Prefab) as GameObject;
            }
            else
            {
                enemy = Instantiate(enemy2Prefab) as GameObject;
            }
        }
    }
}
