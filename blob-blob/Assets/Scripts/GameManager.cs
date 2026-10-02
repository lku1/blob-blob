using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public State GameState;
    public GameObject Background;
    public PipeController PC;
    public TextMeshProUGUI ScoreText;
    public GameObject Player;
    public Transform StartPoint;
    public DifficultyManager DM;
    public ScoreManager SM;
    private int currentScore;

    public void Setup()
    {
        currentScore = 0;
        ScoreText.text = "0";
        Background.SetActive(true);
        DM = FindAnyObjectByType<DifficultyManager>();
    }

    public void GameStart()
    {
        //TODO UI text Feedback
        GameObject p = Instantiate<GameObject>(Player, StartPoint.position, Quaternion.identity);
        p.GetComponent<PlayerControl>().GM = this;
        StartCoroutine(PC.PipeSpawner());
    }

    public void UpdateScore()
    {
        currentScore++;
        ScoreText.text = currentScore.ToString();
    }

    public void GameOver()
    {
        SM.SaveHighScore(currentScore);
        SceneManager.LoadScene("MenuScene");
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

    void Start()
    {
        ScoreText.text = "0";
        Background.SetActive(true);
        GameStart();

    }
}

public enum State
{
    Waiting, Running, Paused
}