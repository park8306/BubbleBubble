using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public int moveForwardFrame = 6;
    public int currentFrame = 0;
    public float speed = 1;
    new public Rigidbody2D rigidbody2D;
    public float gravityScale = -0.7f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        if(currentFrame++ < moveForwardFrame)
        {
            var pos = rigidbody2D.position;
            pos.x += (speed * transform.forward.z);
            rigidbody2D.position = pos;
        }
        else
        {
            rigidbody2D.gravityScale = gravityScale;
            enabled = false;
        }
    }
}
