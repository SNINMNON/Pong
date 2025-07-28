using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    private CanvasGroup cg;
    public UnityEngine.UI.Button button;

    void Awake()
    {
        cg = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        button.onClick.AddListener(() => GameManager.Instance.restartEvent.Invoke());
        GameManager.Instance.gameOverEvent.AddListener(ShowGameOver);
        GameManager.Instance.restartEvent.AddListener(HideGameOver);
    }


    void ShowGameOver(GameManager.Side side)
    {
        cg.alpha = 1f;
        cg.interactable = true;
        cg.blocksRaycasts = true;

        string msg = side == GameManager.Side.Left ? "Left Player Wins!" : "Right Player Wins!";
        GetComponentInChildren<TextMeshProUGUI>().text = msg;
    }
    
    void HideGameOver()
    {
        cg.alpha = 0f;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
