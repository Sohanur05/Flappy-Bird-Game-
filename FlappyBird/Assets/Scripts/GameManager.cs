using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{public static GameManager Instance;

    [Header("Canvases")]
    public GameObject startCanvas;
    public GameObject gameOverCanvas;

    [Header("Buttons")]
    public GameObject pauseButton;
    public TextMeshProUGUI pauseButtonText;

    [Header("Bird")]
    public GameObject bird;

    [Header("Score Text")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalHighScoreText;
    public TextMeshProUGUI startHighScoreText;
    //gameover 
    private int score = 0;
    private int highScore = 0;

    private bool gameStarted = false;
    private bool gameOver = false;
    private bool isPaused = false;
//database
    private GameDatabase database;

    void Awake()
    {
        Instance = this;

        Time.timeScale = 0f;

        database = new GameDatabase();

        highScore = database.GetHighScore();

        startCanvas.SetActive(true);

        gameOverCanvas.SetActive(false);

        pauseButton.SetActive(false);

        scoreText.gameObject.SetActive(false);

        scoreText.text = "Score: 0";

        startHighScoreText.text =
            "High Score: " + highScore;
    }

    public void StartGame()
    {
        if (gameStarted)
            return;

        gameStarted = true;
        gameOver = false;
        isPaused = false;

        score = 0;
        startCanvas.SetActive(false);

        gameOverCanvas.SetActive(false);

        pauseButton.SetActive(true);

        bird.SetActive(true);

        scoreText.gameObject.SetActive(true);

        scoreText.text = "Score: 0";

        pauseButtonText.text = "PAUSE";

        Time.timeScale = 1f;
    }

    public void AddScore()
    {
        if (!gameStarted || gameOver)
            return;

        score++;

        scoreText.text = "Score: " + score;

        if (score > highScore)
        {
            highScore = score;
        }
    }

    public void GameOver()
    {
        if (!gameStarted || gameOver)
            return;

        gameOver = true;

        database.SaveScore(score);

        scoreText.gameObject.SetActive(false);

        pauseButton.SetActive(false);

        bird.SetActive(false);


        finalScoreText.text =
            "Score: " + score;

        finalHighScoreText.text =
            "High Score: " + highScore;

        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseGame()
    {
        if (!gameStarted || gameOver)
            return;

        isPaused = true;

        Time.timeScale = 0f;

        pauseButtonText.text = "RESUME";
    }

    public void ResumeGame()
    {
        if (!gameStarted || gameOver)
            return;

        isPaused = false;

        Time.timeScale = 1f;

        pauseButtonText.text = "PAUSE";
    }

    public void TogglePause()
    {
        if (!gameStarted || gameOver)
            return;

        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}