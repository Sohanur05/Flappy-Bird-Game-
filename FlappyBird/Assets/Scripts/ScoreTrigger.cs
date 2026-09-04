using UnityEngine;
public class ScoreTrigger : MonoBehaviour
{
    private bool scored = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (scored)
            return;
        if (other.CompareTag("Player"))
        {
            scored = true;

            GameManager.Instance.AddScore();
        }
    }
}