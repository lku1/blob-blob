using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LogicScript : MonoBehaviour
{
    public State GameState;
    public int playerScore;
    public Text scoreText;
    public Text DeathScreamPoint;

    [Header("Leaderboard Settings")]
    public Text leaderboardText;
    public int scoresToKeep = 5;

    public GameObject gameOverScreen;
    public GameObject PauseButton;
    public GameObject wall;
    public GameObject Scoreboard;

    private List<int> highScoresList = new List<int>();

    // NEW: This tracking switch locks out cheating after death
    private bool isGameOver = false;

    void Start()
    {
        isGameOver = false; // Reset the state on every clean run
        LoadLeaderboard();
        UpdateLeaderboardUI();
    }

    [ContextMenu(" Increase Score ")]
    public void addScore(int scoreToAdd)
    {
        // NEW: If the game is already over, reject any incoming points completely!
        if (isGameOver) return;

        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        DeathScreamPoint.text = playerScore.ToString();
    }

    public void CheckAndSaveHighScore(int newScore)
    {
        highScoresList.Add(newScore);
        highScoresList.Sort((a, b) => b.CompareTo(a));

        while (highScoresList.Count > scoresToKeep)
        {
            highScoresList.RemoveAt(highScoresList.Count - 1);
        }

        for (int i = 0; i < scoresToKeep; i++)
        {
            if (i < highScoresList.Count)
            {
                PlayerPrefs.SetInt("HighScore_" + i, highScoresList[i]);
            }
            else
            {
                PlayerPrefs.SetInt("HighScore_" + i, 0);
            }
        }
        PlayerPrefs.Save();
        UpdateLeaderboardUI();
    }

    void LoadLeaderboard()
    {
        highScoresList.Clear();
        for (int i = 0; i < scoresToKeep; i++)
        {
            int savedScore = PlayerPrefs.GetInt("HighScore_" + i, 0);
            if (savedScore > 0 || i == 0)
            {
                highScoresList.Add(savedScore);
            }
        }
    }

    void UpdateLeaderboardUI()
    {
        if (leaderboardText != null)
        {
            leaderboardText.text = "Top Scores\n";
            for (int i = 0; i < highScoresList.Count; i++)
            {
                leaderboardText.text += (i + 1) + ". " + highScoresList[i] + "\n";
            }
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        // FIX: If the game is already over, EXIT IMMEDIATELY. 
        // This prevents the code below from running multiple times!
        if (isGameOver) return;

        // Flip the switch to true so any future hits this frame are ignored
        isGameOver = true;

        // Now this will only run EXACTLY ONCE per death screen
        CheckAndSaveHighScore(playerScore);

        gameOverScreen.SetActive(true);
        PauseButton.SetActive(false);
        wall.SetActive(false);
        Scoreboard.SetActive(false);
    }

    public void OnPauseButtonClick()
    {
        Pause(GameState != State.Paused);
    }

    void Pause(bool paused)
    {
        GameState = paused ? State.Paused : State.Running;
        Time.timeScale = paused ? 0f : 1f;
    }

    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetLeaderboard()
    {
        for (int i = 0; i < scoresToKeep; i++)
        {
            PlayerPrefs.DeleteKey("HighScore_" + i);
        }
        PlayerPrefs.Save();
        highScoresList.Clear();
        highScoresList.Add(0);
        UpdateLeaderboardUI();
    }
}
