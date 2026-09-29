using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float HorizontalForce;

    void Update()
    {
        transform.position += Vector3.left * HorizontalForce * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathWall"))
            Destroy(gameObject);
    }
}
