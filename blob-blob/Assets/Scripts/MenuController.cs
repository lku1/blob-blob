using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MenuScreen;
    public ScoreManager ScoreManager;
    public TextMeshProUGUI ScoreText;
    void Start()
    {
        MenuScreen.SetActive(true);
        int? currentHighest = ScoreManager.GetHighScore();

        if (currentHighest == null || currentHighest <= 0)
            ScoreText.text = "You can be the first!";

        else
            ScoreText.text = currentHighest.ToString();
    }

    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
