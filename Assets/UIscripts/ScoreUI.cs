using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private int leftScore = 0;
    private int rightScore = 0;

    private TextMeshProUGUI leftScoreText;
    private TextMeshProUGUI rightScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.scoreEvent.AddListener(UpdateScore);
        GameManager.Instance.restartEvent.AddListener(ResetScore);

        leftScoreText = transform.Find("ScoreLeft").GetComponent<TextMeshProUGUI>();
        rightScoreText = transform.Find("ScoreRight").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore(GameManager.Side side)
    {
        //Debug.Log("UpdateScore called for side: " + side);
        if (side == GameManager.Side.Left)
        {
            leftScore++;
            leftScoreText.text = "Score: " + leftScore.ToString();
        }
        else
        {
            rightScore++;
            rightScoreText.text = "Score: " + rightScore.ToString();
        }

        if (leftScore >= GameManager.Instance.winningScore ||
            rightScore >= GameManager.Instance.winningScore)
        {
            GameManager.Instance.gameOverEvent.Invoke(side);
        }
    }

    void ResetScore()
    {
        leftScore = 0;
        rightScore = 0;
        leftScoreText.text = "Score: " + leftScore.ToString();
        rightScoreText.text = "Score: " + rightScore.ToString();
    }
}
