using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector2.up * jumpForce;}
    }private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") ||
            collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();}}}}