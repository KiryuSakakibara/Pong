using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI AIScoreText;
    public GameObject ball;
    public Paddle playerPaddle;
    public Paddle enemyPaddle;
    private bool gameOver = false;
    private int playerScore = 0;
    private int AIScore = 0;
    public Vector2 bounds;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        if (!ball || gameOver) return;

        if (ball.transform.position.x > bounds.x) {
            AIScore++;
            AIScoreText.SetText(AIScore.ToString());
            StartCoroutine(ResetGame());
        } else if (ball.transform.position.x < -bounds.x) {
            playerScore++;
            playerScoreText.SetText(playerScore.ToString());
            StartCoroutine(ResetGame());
        }
    }

    private IEnumerator ResetGame() {
        gameOver = true;
        yield return new WaitForSeconds(1);
        gameOver = false;
        ball.GetComponent<Ball>().Reset();
        playerPaddle.Reset();
        enemyPaddle.Reset();
    }
}
