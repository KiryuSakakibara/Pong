using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIPaddle : Paddle {

    public GameObject ball;

    protected override void ProcessMovement() {
        if (!ball) return; // Ball doesn't exist

        float moveSpeed = Math.Min(speed, Math.Abs(ball.GetComponent<Rigidbody2D>().velocity.y));

        if (ball.transform.position.y > transform.position.y + 0.5) {
            rb.velocity = moveSpeed * Vector2.up;
        } else if (ball.transform.position.y < transform.position.y - 0.5) {
            rb.velocity = -moveSpeed * Vector2.up;
        }
    }

    protected override void ProcessShoot() {
        if (remainingCooldown <= 0) {
            bulletPool.SpawnBullet(transform.position, new Vector2(10, 0));
            remainingCooldown = maxCooldown;
        }
    }

}
