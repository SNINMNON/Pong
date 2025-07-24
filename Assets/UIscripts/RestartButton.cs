using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RestartButton : MonoBehaviour
{
    public UnityEngine.UI.Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        Debug.Log("game restart");
        GameManager.Instance.RestartGame();
    }
}
