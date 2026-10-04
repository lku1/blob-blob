using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public State GameState;
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject PauseButton;
    public GameObject wall;

    [ContextMenu(" Increase Score ")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        PauseButton.SetActive(false);
        wall.SetActive(false);
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
}