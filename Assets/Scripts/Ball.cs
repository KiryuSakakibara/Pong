using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float ballSpeed = 5;

    Rigidbody2D rb;
    float ballVerticalBound;
    float ballHorizontalBound;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float ballRadius = GetComponent<CircleCollider2D>().bounds.size.y/2;
        ballVerticalBound = bounds.y - ballRadius;
        ballHorizontalBound = bounds.x - ballRadius;

        Reset();
    }

    void FixedUpdate() {
        float y = transform.position.y;
        if (y >= ballVerticalBound || y <= -ballVerticalBound) {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
        
    }
    
    public void Reset() {
        transform.position = Vector2.zero;
        //float randAngle = Random.Range(7*Mathf.PI/8, 9*Mathf.PI/8);
        float randAngle = Random.Range(-Mathf.PI/4, Mathf.PI/4);
        rb.velocity = new Vector2(Mathf.Cos(randAngle), Mathf.Sin(randAngle)) * ballSpeed;
    }
}
