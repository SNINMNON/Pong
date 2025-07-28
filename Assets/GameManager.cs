using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject ballPrefab;
    private GameObject ball;

    public enum Side { Left, Right }
    public UnityEvent<Side> scoreEvent;
    public UnityEvent<Side> gameOverEvent;
    public UnityEvent restartEvent;

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
        ball = Instantiate(ballPrefab);
    }

    void Start()
    {
        gameOverEvent.AddListener(side => Destroy(ball));
        restartEvent.AddListener(() => ball = Instantiate(ballPrefab));
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

}
