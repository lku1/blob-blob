using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -13;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;


        if (transform.position.x < deadZone)
        {
            Debug.Log(" Pipe Deleted ");
            Destroy(gameObject);
        }
    }
}