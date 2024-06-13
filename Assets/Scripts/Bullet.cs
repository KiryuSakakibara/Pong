using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float remainingTime = 3;
    private float maxRemainingTime = 3;

    void FixedUpdate() {
        if (remainingTime <= 0) {
            gameObject.SetActive(false);
        } else {
            remainingTime -= Time.fixedDeltaTime;
        }
    }

    void OnEnable() {
        remainingTime = maxRemainingTime;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        gameObject.SetActive(false);
        collision.gameObject.GetComponent<Paddle>().DealDamage(1);
    }

}
