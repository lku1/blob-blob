using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public State GameState;
    public GameObject MenuScreen;
    public GameObject Background;
    public PipeController PC;
    public float Timer;
    public TextMeshProUGUI TimerText;
    public GameObject Player;
    public Transform StartPoint;

    public void GameStart()
    {
        MenuScreen.SetActive(false);
        Background.SetActive(false);
        GameState = State.Running;
        //TODO UI text Feedback
        GameObject p = Instantiate<GameObject>(Player, StartPoint.position, Quaternion.identity);
        p.GetComponent<PlayerControl>().GM = this;
        StartCoroutine(PC.PipeSpawner());
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPauseButtonClick()
    {
        Pause(GameState != State.Paused);
    }

    void Pause(bool paused)
    {
        if (GameState == State.Waiting)
            return;

        GameState = paused ? State.Paused : State.Running;
        Time.timeScale = paused ? 0f : 1f;
    }

    void Start()
    {
        GameState = State.Waiting;
        Timer = 0;
        TimerText.text = "";
        MenuScreen.SetActive(true);
        Background.SetActive(true);
    }

    void Update()
    {
        Timer += Time.deltaTime;
        TimerText.text = Timer.ToString("F2");
    }
}

public enum State
{
    Waiting, Running, Paused
}