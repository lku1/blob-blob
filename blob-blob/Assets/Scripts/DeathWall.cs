using UnityEngine;

public class DeathWall : MonoBehaviour
{
    private BoxCollider2D BC;
    private void Start()
    {
        BC = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyImmediate(collision.gameObject);
    }
}