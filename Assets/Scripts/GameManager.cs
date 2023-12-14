using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverUI;

    private AudioSource gameOverAudio;
    private int score = 0;
    private float timer = 60f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameOverAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        timerText.text = "Timer: " + ((int)timer).ToString();

        if (timer <= 0f)
        {
            GameOver();
        }
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        gameOverAudio.Play();
        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
    }
}
