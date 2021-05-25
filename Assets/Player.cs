using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.1f;

    public Animator animator;
    new public Collider2D collider2D;

    new public Rigidbody2D rigidbody2D;

    public float jumpForce = 100f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        FireBubble();
        // WASD, W위로, A왼쪽,S아래, D오른쪽
        Move();

        Jump();
    }

    private void Jump()
    {
        // 낙하할 때는 지면과 충돌하도록 isTrigger를 꺼주자.
        if(rigidbody2D.velocity.y < 0)
        {
            collider2D.isTrigger = false;
        }

        if (rigidbody2D.velocity.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                rigidbody2D.AddForce(new Vector2(0, jumpForce));
                collider2D.isTrigger = true;
            }
        }
    }

    public GameObject bubble;
    public Transform bubbleSpawnPos;

    private void FireBubble()
    {
        // 스페이스 누르면 버블 날리기.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bubble, bubbleSpawnPos.position, transform.rotation);
        }
    }

    public float minX, maxX;

    private void Move()
    {
        float moveX = 0;
        // || -> or

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) moveX = -1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) moveX = 1;
        Vector3 position = transform.position;
        position.x = position.x + moveX * speed;
        position.x = Mathf.Max(minX, position.x);
        position.x = Mathf.Min(maxX, position.x);
        transform.position = position;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack") == false)
        {
            if (moveX != 0)
            {
                // moveX 양수이면 180 로테이션 아니면 0도 로테이션 적용.
                float rotateY = 0;
                if (moveX < 0)
                {
                    rotateY = 180;
                }
                var rotation = transform.rotation;
                rotation.y = rotateY;
                transform.rotation = rotation;
                animator.Play("run");
            }
            else
                animator.Play("Idle");
        }
    }
}
