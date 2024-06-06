using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle {

    protected override void ProcessMovement() {
        rb.velocity = Input.GetAxisRaw("Vertical") * speed * Vector2.up;
    }

}
