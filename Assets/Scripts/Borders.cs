using UnityEngine;

public class Borders : MonoBehaviour
{
    public Transform respawnPoint; 

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            RespawnBall(other.gameObject);
        }
    }

    private void RespawnBall(GameObject ball)
    {
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
        }

        if (respawnPoint != null)
        {
            ball.transform.position = respawnPoint.position;
        }
    }
}
