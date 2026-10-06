using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
    }
}
