using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Paddle : MonoBehaviour {

    // Paddle speed
    public float speed = 5;

    protected Rigidbody2D rb;
    // The game bounds that the paddle can be within, taking into account paddle size
    private float paddleBound;

    public BulletPool bulletPool;
    // The cooldown until the paddle can shoot again, in seconds
    protected float remainingCooldown = 0;
    protected float maxCooldown = 0.5f;

    private int health = 20;
    private int maxHealth = 20;

    // Start is called before the first frame update
    protected virtual void Start() {
        rb = GetComponent<Rigidbody2D>();

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float paddleHeight = GetComponent<Collider2D>().bounds.size.y/2;
        paddleBound = screenBounds.y - paddleHeight;
    }

    // Update is called once per frame
    void Update() {
        ProcessMovement();
        ProcessShoot();

        Vector2 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -paddleBound, paddleBound);
        transform.position = pos;
    }

    void FixedUpdate() {
        if (maxCooldown > 0) {
            remainingCooldown -= Time.fixedDeltaTime;
        }

        float yScale = 3f * health / maxHealth;
        transform.localScale = new Vector3(transform.localScale.x, yScale, 1);
        paddleBound = GameManager.Instance.bounds.y - GetComponent<Collider2D>().bounds.size.y/2;
    }

    // Handles the movement for the associated paddle
    protected abstract void ProcessMovement();

    protected abstract void ProcessShoot();
    
    public void DealDamage(int damage) {
        health -= damage;
    }

    public void Reset() {
        health = maxHealth;
        bulletPool.Reset();
        remainingCooldown = 0;
        transform.position = new Vector2(transform.position.x, 0);
    }
}
