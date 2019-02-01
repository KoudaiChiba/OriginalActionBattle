using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -0.05f;

    // 消滅位置
    private float deadLine = -10;

    private float interval = 0.2f;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AttackAreaTag")
        {
            this.animator.SetTrigger("deathTrigger");

            Invoke("Destroy", 0.3f);
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
