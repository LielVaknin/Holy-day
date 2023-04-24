using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro timerText;
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private int startingLife = 3;
    [SerializeField] private TextMeshPro lifeText;
    [SerializeField] private float gameTimeInSeconds = 30f;
    [SerializeField] private static int maxScore = 4;
    [SerializeField] private GameObject[] itemsToCollect;
    [SerializeField] private string nextSceneName;

    private float remainingTimeInSeconds;
    private static int score;
    private int life;
    private bool isGameOver;
    private const string TIME_PREFIX = "Time: ";
    private const string SCORE_PREFIX = "Score: ";
    private const string LIFE_PREFIX = "Life: ";
    
    void Start()
    {
        remainingTimeInSeconds = gameTimeInSeconds;
        score = 0;
        life = startingLife;
        isGameOver = false;
        UpdateTimerText();
        UpdateScoreText();
        UpdateLifeText();
    }

    void Update()
    {
        if (!isGameOver)
        {
            remainingTimeInSeconds -= Time.deltaTime;
            if (remainingTimeInSeconds <= 0)
            {
                EndGame();
            }
            else
            {
                UpdateTimerText();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isGameOver)
        {
            foreach (GameObject item in itemsToCollect)
            {
                if (other.gameObject == item)
                {
                    score++;
                    Destroy(item);
                    UpdateScoreText();
                    if (score >= maxScore)
                    {
                        EndGame();
                    }
                    return;
                }
            }
            life--;
            Destroy(other.gameObject);
            UpdateLifeText();
            if (life <= 0)
            {
                EndGame();
            }
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = TIME_PREFIX + Mathf.RoundToInt(remainingTimeInSeconds).ToString();
    }

    private void UpdateScoreText()
    {
        scoreText.text = SCORE_PREFIX + score.ToString() + "/" + maxScore.ToString();
    }

    private void UpdateLifeText()
    {
        lifeText.text = LIFE_PREFIX + life.ToString();
    }

    private void EndGame()
    {
        isGameOver = true;
        SceneManager.LoadScene(nextSceneName);

    }

    public static int GetMaxScore()
    {
        return maxScore;
    }

    public static int GetScore()
    {
        return score;
    }
}
