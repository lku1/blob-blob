using UnityEngine;

public class Enemyscript : MonoBehaviour
{
    public enum MovementType { Straight, Wavy }

    [Header("Movement Mode")]
    public MovementType chosenMovement;

    [Header("Horizontal Settings")]
    public float moveSpeed = 8;
    public float deadZone = 12;

    [Header("Wave Random Limits")]
    public float minFrequency = 2f;    // Slowest speed
    public float maxFrequency = 8f;    // Fastest speed
    public float minMagnitude = 0.2f;  // Smallest height range
    public float maxMagnitude = 1.5f;  // Tallest height range

    // These will hold the unique randomized values for this specific enemy instance
    private float randomizedFrequency;
    private float randomizedMagnitude;

    bool facingRight = false;
    Vector3 pos, localScale;

    void Start()
    {
        pos = transform.position;
        localScale = transform.localScale;

        // RANDOMIZER 1: Decide if it goes straight or wavy (0 = Straight, 1 = Wavy)
        int randomRoll = Random.Range(0, 2);
        chosenMovement = (MovementType)randomRoll;

        // RANDOMIZER 2: Pick unique wave intensity values for this specific enemy
        randomizedFrequency = Random.Range(minFrequency, maxFrequency);
        randomizedMagnitude = Random.Range(minMagnitude, maxMagnitude);
    }

    void Update()
    {
        if (transform.position.x > deadZone)
        {
            Debug.Log(" Pipe Deleted ");
            Destroy(gameObject);
            return;
        }

        CheckWhereToFace();

        // Calculate horizontal positions using your bounce variables
        if (facingRight)
            MoveRight();
        else
            MoveLeft();

        // Apply horizontal movement
        transform.position = pos;

        // Only add the up-and-down wave pattern if Wavy movement was chosen
        // Uses the unique randomized parameters rolled at birth
        if (chosenMovement == MovementType.Wavy)
        {
            transform.position += transform.up * Mathf.Sin(Time.time * randomizedFrequency) * randomizedMagnitude;
        }
    }

    void CheckWhereToFace()
    {
        if (pos.x < -13f)
            facingRight = true;

        else if (pos.x > 20f)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
    }

    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
    }
}
