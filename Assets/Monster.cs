using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    // 앞으로 움직이자.
    // 벽을 만나면 뒤로 방향 전환.
    Rigidbody2D rigidbody2D;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    public float speed = 0.1f;
    void FixedUpdate()
    {
        var pos = rigidbody2D.position;
        pos.x += speed * transform.forward.z;
        rigidbody2D.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rotation = transform.rotation;
        if(rotation.y == 0)
        {
            rotation.y = 180;
        }
        else
        {
            rotation.y = 0;
        }
        transform.rotation = rotation;
    }
}
