using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject ballPrefab;
    private GameObject ball;
    public GameObject leftPaddle;
    public GameObject rightPaddle;

    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    public CanvasGroup gameOverUI;

    private int leftScore = 0;
    private int rightScore = 0;
    public int winningScore = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    void Start()
    {
        ball = Instantiate(ballPrefab);
        ball.GetComponent<BallMovement>().Restart();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void Score(bool left)
    {
        if (left)
        {
            rightScore++;
            rightScoreText.text = "Score: " + rightScore.ToString();
        }
        else
        {
            leftScore++;
            leftScoreText.text = "Score: " + leftScore.ToString();
        }
        CheckGameOver();
        ball.GetComponent<BallMovement>().Restart();
    }

    private void CheckGameOver()
    {
        if (leftScore >= winningScore)
        {
            Destroy(ball);
            ShowGameOver("Left Player Wins!");
        }
        else if (rightScore >= winningScore)
        {
            Destroy(ball);
            ShowGameOver("Right Player Wins!");
        }
    }

    private void ShowGameOver(string msg)
    {
        gameOverUI.alpha = 1f;
        gameOverUI.interactable = true;
        gameOverUI.blocksRaycasts = true;
        gameOverUI.GetComponentInChildren<TextMeshProUGUI>().text = msg;
    }

    private void HideGameOver()
    {
        gameOverUI.alpha = 0f;
        gameOverUI.interactable = false;
        gameOverUI.blocksRaycasts = false;
    }

    public void RestartGame()
    {
        leftScore = 0;
        rightScore = 0;
        leftScoreText.text = "Score: " + leftScore.ToString();
        rightScoreText.text = "Score: " + rightScore.ToString();
        HideGameOver();
        ball = Instantiate(ballPrefab);
        ball.GetComponent<BallMovement>().Restart();

        leftPaddle.GetComponent<Paddle>().transform.position = new Vector3(-8, 0, 0);
        rightPaddle.GetComponent<Paddle>().transform.position = new Vector3(8, 0, 0);
    }
}
