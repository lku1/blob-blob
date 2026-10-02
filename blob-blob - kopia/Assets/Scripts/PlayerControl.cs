using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float JumpForce;
    public GameManager GM;
    private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

        if (RB != null)
            Debug.Log("Rb is set");
    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (GM.GameState == State.Paused)
            return;

        if (Input.GetButtonDown("Jump"))
            RB.AddForceY(JumpForce, ForceMode2D.Impulse);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            RB.AddForceY(JumpForce, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Pipe"))
            GM.GameOver();
        
        if (collision.gameObject.CompareTag("ScoreZone"))
            GM.UpdateScore();
    }
}