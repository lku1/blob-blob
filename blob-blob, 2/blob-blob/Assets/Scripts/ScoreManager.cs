using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
    public void SaveHighScore(int score)
    {
        int currentBest = PlayerPrefs.GetInt("HighScore", 0);

        if (currentBest < score)
        {
            PlayerPrefs.SetInt("HighScore", score);

        PlayerPrefs.Save();
        }
    }
}
