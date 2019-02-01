using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;

    Animator animator;

    private float groundLevel = -3.0f;

    private float dump = 0.8f;

    private float walkForce = 10.0f;

    private float deadLine = -7.0f;

    private float overLine = 8.0f;

    float jumpVelocity = 25;

    private float interVal = 1.0f;

    private float nextTime;

    private bool isDamege = false;

    private float sumTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();

        this.animator = GetComponent<Animator>();

        nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        int key = 0;

        bool isGround = (transform.position.y > this.groundLevel) ? false : true;

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            this.animator.SetTrigger("jumpTrigger");
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && this.deadLine < this.transform.position.x)
        {
            key = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.overLine > this.transform.position.x)
        {
            key = 1;
        }
        else
        {
            key = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.animator.SetTrigger("attackTrigger");
        }

        rigid2D.velocity = new Vector2(walkForce * key, rigid2D.velocity.y);


        if (isDamege == true)
        {
            sumTime += Time.deltaTime;
            var renderComponent = GetComponent<Renderer>();
            if (sumTime < 2.0)
            {
                if (Time.time > nextTime)
                {
                    interVal = 0.0f;
                    renderComponent.enabled = !renderComponent.enabled;
                }
            }
            else
            {
                renderComponent.enabled = true;
                isDamege = false;
                sumTime = 0.0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Player")
        {
            this.animator.SetTrigger("damegeTrigger");
            isDamege = true;
        }
    }
}