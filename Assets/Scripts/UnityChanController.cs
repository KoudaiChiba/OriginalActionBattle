using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    Animator animator;

    Rigidbody2D rigid2D;

    private float groundLevel = -3.0f;

    private float dump = 0.8f;

    float jumpVelocity = 20;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();

        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.animator.SetFloat("Horizontal", 1);

        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        // ジャンプ状態のときにはボリュームを0にする（追加）
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        if (Input.GetMouseButtonDown(0) && isGround)
        {
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        
    }
}
