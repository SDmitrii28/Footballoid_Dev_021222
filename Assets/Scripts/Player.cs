using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float moveX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveX = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        Vector3 velo = Vector2.zero;
        velo.x = moveX * speed;
        velo.y = rb.velocity.y;
        rb.velocity = velo;
    }
    private void FixedUpdate()
    {
        Vector3 acceleration = Input.acceleration;
        rb.velocity = new Vector3(acceleration.x*speed, 0f, 0f);
    }
}
