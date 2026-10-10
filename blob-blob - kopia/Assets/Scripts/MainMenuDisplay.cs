using UnityEngine;
using UnityEngine.UI;

public class MainMenuDisplay : MonoBehaviour
{
    public Text menuLeaderboardText;
    public int scoresToDisplay = 5;

    void Start()
    {
        RefreshLeaderboardUI();
    }

    // Pulls the scores and prints them to the UI text box
    public void RefreshLeaderboardUI()
    {
        if (menuLeaderboardText != null)
        {
            menuLeaderboardText.text = "Leaderboard\n";

            for (int i = 0; i < scoresToDisplay; i++)
            {
                int savedScore = PlayerPrefs.GetInt("HighScore_" + i, 0);
                menuLeaderboardText.text += (i + 1) + ". " + savedScore + "\n";
            }
        }
    }

    // Call this function via a UI Button to wipe scores from the Main Menu
    public void ResetLeaderboardData()
    {
        for (int i = 0; i < scoresToDisplay; i++)
        {
            PlayerPrefs.DeleteKey("HighScore_" + i);
        }
        PlayerPrefs.Save();

        // Immediately update the visual numbers back to zeros
        RefreshLeaderboardUI();
        Debug.Log("Main Menu Leaderboard data wiped.");
    }
}
