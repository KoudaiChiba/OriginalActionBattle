using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // 敵の移動速度
    private float speed = -0.05f;

    // 消滅位置
    private float deadLine = -11;

    //消滅アニメーション用
    public GameObject enemydead;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //敵のアニメーターコンポーネント取得
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 敵を右に移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤーの攻撃範囲に当たったら
        if (other.gameObject.tag == "AttackAreaTag")
        {
            //敵オブジェクト破棄
            Destroy(gameObject);

            //消滅アニメーションのプレハブを生成
            Instantiate(enemydead, transform.position, transform.rotation);
        }
        //プレイヤーに当たったら
        else if(other.gameObject.tag == "Player")
        {
            GameObject generator = GameObject.Find("UIGenerator");
            generator.GetComponent<UIController>().DecreaseHp();
            var go = GameObject.FindGameObjectWithTag("Player");
            var p = go.GetComponent<PlayerController>();
            if(p)
            {
                p.Damage(1);
            }
        }
    }
}
