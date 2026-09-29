using System.Collections;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    #region Declarations
    public float SecondDelay;
    public GameObject HigherPipe;
    public GameObject LowerPipe;
    public GameObject DoublePipe;
    public Transform LowerPoint;
    public Transform HighPoint;
    public Transform MiddlePoint;
    public GameManager GM;
    #endregion


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
        int random = (int)Random.Range(0, 2);
        if (random == 0)
            Instantiate<GameObject>(LowerPipe, LowerPoint.position, Quaternion.identity);
        else if (random == 1)
            Instantiate<GameObject>(DoublePipe, MiddlePoint.position, Quaternion.identity);
        else if (random == 2)
            Instantiate<GameObject>(HigherPipe, HighPoint.position, Quaternion.identity);
    }

    void Update()
    {

    }
}