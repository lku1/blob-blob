using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float HorizontalSpeed;

    void Update()
    {
        transform.position += Vector3.left * HorizontalSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathWall"))
            Destroy(gameObject);
    }
}
