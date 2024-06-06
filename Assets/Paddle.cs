using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Paddle : MonoBehaviour {

    public float speed = 5;

    protected Rigidbody2D rb;
    float paddleBound;

    // Start is called before the first frame update
    protected virtual void Start() {
        rb = GetComponent<Rigidbody2D>();

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float paddleHeight = GetComponent<Collider2D>().bounds.size.y/2;
        paddleBound = screenBounds.y - paddleHeight;
    }

    // Update is called once per frame
    void Update() {
        Vector2 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -paddleBound, paddleBound);
        transform.position = pos;
    }

    void FixedUpdate() {
        ProcessMovement();
    }

    // Handles the movement for the associated paddle
    protected abstract void ProcessMovement();
}
