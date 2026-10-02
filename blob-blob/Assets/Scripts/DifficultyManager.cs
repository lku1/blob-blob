using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance { get; private set; }
    public Difficulty CurrentDifficulty;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetNormal()
    {
        CurrentDifficulty = Difficulty.Normal;
    }
    public void SetHard()
    {
        CurrentDifficulty = Difficulty.Hard;
    }
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}

public enum Difficulty
{
    Normal, Hard
}

