using UnityEngine;
public class PipeMovement : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        if (GameManager.Instance == null)
            return;

        transform.position += Vector3.left * speed * Time.deltaTime;}}