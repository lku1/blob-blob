using UnityEngine;
using UnityEngine.U2D;

public class SpriteTilt : MonoBehaviour
{
    public Rigidbody2D RB;
    public Transform SpriteBody;
    void Update()
    {
        float angle = Mathf.Clamp(RB.linearVelocity.y * 8f, -25f, 25f);
        SpriteBody.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}
