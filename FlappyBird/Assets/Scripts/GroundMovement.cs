using UnityEngine;
public class GroundMovement : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            transform.position = new Vector3(10f, transform.position.y, transform.position.z); } }}