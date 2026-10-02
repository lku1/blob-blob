using NUnit.Framework;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float JumpForce;
    public Transform SpriteBody;
    public LogicScript logic;
    public bool playerIsAlive = true;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        Jump();

        float angle = Mathf.Clamp(myRigidbody.linearVelocity.y * 8f, -20f, 20f);
        SpriteBody.localRotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Jump()
    {

        if (Input.GetButtonDown("Jump") && playerIsAlive)
            myRigidbody.AddForceY(JumpForce, ForceMode2D.Impulse);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && playerIsAlive)
            myRigidbody.AddForceY(JumpForce, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision )
    {
        logic.gameOver();
        playerIsAlive = false;
    }
}