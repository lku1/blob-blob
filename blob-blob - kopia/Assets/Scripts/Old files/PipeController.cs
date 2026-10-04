using System.Collections;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    #region Declarations
    public GameObject HigherPipe;
    public GameObject LowerPipe;
    public GameObject DoublePipe;
    public Transform LowerPoint;
    public Transform HighPoint;
    public Transform MiddlePoint;
    public GameManager GM;
    public float CurrentSpeed;
    public float SecondDelay;
    #endregion

    private void Setup()
    {
        if (DifficultyManager.Instance.CurrentDifficulty == Difficulty.Normal)

        {
            CurrentSpeed = 5f;
            SecondDelay = 5f;
        }
        if (DifficultyManager.Instance.CurrentDifficulty == Difficulty.Hard)
        {
            CurrentSpeed = 6f;
            SecondDelay = 4f;
        }

        GM.GameState = State.Running;
        GM.GameStart();
    }

    public IEnumerator PipeSpawner()
    {
        while (GM.GameState == State.Running)
        {
            Spawn();
            yield return new WaitForSeconds(SecondDelay);
        }
    }

    void Spawn()
    {
        int random = (int)Random.Range(0, 3);
        if (random == 0)
        {
            var p = Instantiate<GameObject>(LowerPipe, LowerPoint.position, Quaternion.identity);
            p.GetComponent<PipeMovement>().HorizontalSpeed = CurrentSpeed;
        }
        else if (random == 1)
        {
            var p = Instantiate<GameObject>(DoublePipe, MiddlePoint.position, Quaternion.identity);
            p.GetComponent<PipeMovement>().HorizontalSpeed = CurrentSpeed;
        }
        else if (random == 2)
        {
            var p = Instantiate<GameObject>(HigherPipe, HighPoint.position, Quaternion.identity);
            p.GetComponent<PipeMovement>().HorizontalSpeed = CurrentSpeed;
        }
    }
}