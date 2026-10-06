using UnityEngine;
using UnityEngine.InputSystem;

public class BallDropper : MonoBehaviour
{
    public GameObject BallPrefab;
    // Update is called once per frame
    void Update()
    {
        // if the left mouse button was pressed
        if (Mouse.current.leftButton.wasPressedThisFrame && Game.IsGameStarted())
        {
            DropBall();
        }
    }

    private void DropBall()
    {
        // pick a position to start at
        Vector3 spawnPosition = GetSpawnPosition();
        
        // create a ball at that position
        GameObject ball = Instantiate(BallPrefab, spawnPosition, Quaternion.identity);

        AddRandomForce(ball);
    }

    private void AddRandomForce(GameObject ball)
    {
        Rigidbody2D rigidbody = ball.GetComponent<Rigidbody2D>();

        float randomHorizontalForce = Random.Range(-5.5f, 5.5f);
        rigidbody.AddForce(new Vector2(randomHorizontalForce, 0f), ForceMode2D.Impulse);
    }

    public Vector3 GetSpawnPosition()
    {
        Vector3 leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane));

        float randomX = Random.Range(leftEdge.x + 1, rightEdge.x - 1);

        Vector3 spawnPosition = new Vector3(randomX, 4.5f, 0f);

        return spawnPosition;

    }
}
