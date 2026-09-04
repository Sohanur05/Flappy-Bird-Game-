using UnityEngine;

public class BirdAnimation : MonoBehaviour
{public float upAngle = 25f;
    public float downAngle = -60f;
    public float rotationSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float targetAngle;

        if (rb.linearVelocity.y > 0)
        {
            targetAngle = upAngle;
        } else
        {
            targetAngle = downAngle;}
        Quaternion targetRotation =
            Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}