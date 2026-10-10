using UnityEngine;

public class SpearScript : MonoBehaviour
{
    public enum MovementType { Straight, Wavy }

    [Header("Movement Mode")]
    public MovementType chosenMovement;

    [Header("Horizontal Settings")]
    public float minMoveSpeed = 3f;  // Slowest speed limit
    public float maxMoveSpeed = 11f; // Fastest speed limit
    public float deadZone = -13f;

    [Header("Wave Random Limits")]
    public float minFrequency = 2f;
    public float maxFrequency = 8f;
    public float minMagnitude = 0.2f;
    public float maxMagnitude = 1.5f;

    private float randomizedSpeed;
    private float randomizedFrequency;
    private float randomizedMagnitude;
    private float verticalStartY;

    void Start()
    {
        // Remember the original height the spear spawned at
        verticalStartY = transform.position.y;

        // RANDOMIZER 1: Straight vs Wavy
        int randomRoll = Random.Range(0, 2);
        chosenMovement = (MovementType)randomRoll;

        // RANDOMIZER 2: Speed calculation
        randomizedSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        // RANDOMIZER 3: Random wave values
        randomizedFrequency = Random.Range(minFrequency, maxFrequency);
        randomizedMagnitude = Random.Range(minMagnitude, maxMagnitude);
    }

    void Update()
    {
        // Move steadily from right to left using the unique randomized speed
        transform.Translate(Vector3.left * randomizedSpeed * Time.deltaTime, Space.World);

        // Check if the spear went past the left deadzone threshold
        if (transform.position.x < deadZone)
        {
            Debug.Log("Spear Deleted");
            Destroy(gameObject);
            return;
        }

        // Apply the wave oscillation on the Y-axis if Wavy is selected
        if (chosenMovement == MovementType.Wavy)
        {
            float newY = verticalStartY + Mathf.Sin(Time.time * randomizedFrequency) * randomizedMagnitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}
