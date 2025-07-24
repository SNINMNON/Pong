using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public BallMovement ball;

    private int leftScore = 0;
    private int rightScore = 0;

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

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void Score(bool left)
    {
        ball.Restart();
        if (left)
        {
            leftScore++;
            Debug.Log($"left scored: {leftScore}");
        }
        else
        {
            rightScore++;
            Debug.Log($"right scored: {rightScore}");
        }
    }
}
