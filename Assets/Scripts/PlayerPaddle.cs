using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle {

    protected override void ProcessMovement() {
        rb.velocity = Input.GetAxisRaw("Vertical") * speed * Vector2.up;
    }

    protected override void ProcessShoot() {
        if (Input.GetKey(KeyCode.Space) && remainingCooldown <= 0) {
            bulletPool.SpawnBullet(gameObject.transform.position, new Vector2(-10, 0));
            remainingCooldown = maxCooldown;
        }
    }

}
