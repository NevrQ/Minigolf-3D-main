using UnityEngine;

public class Hole : MonoBehaviour
{
    public string ballTag = "Ball";
    public float holeDetectionRadius = 0.5f; 
    public Transform holeCenter; 

    private void Update()
    {
        // Ensure holeCenter is set
        if (holeCenter == null)
        {
            Debug.LogError("Hole Center is not assigned.");
            return;
        }

        Collider[] colliders = Physics.OverlapSphere(holeCenter.position, holeDetectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(ballTag))
            {
                BallEnteredHole(collider.gameObject);
                break;
            }
        }
    }

    private void BallEnteredHole(GameObject ball)
    {
        Debug.Log("Ball has entered the hole!");
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.isKinematic = true;
        }

        ball.transform.position = holeCenter.position;

        OnBallInHole();
    }

    private void OnBallInHole()
    {
        Debug.Log("Trigger level completion or scoring logic here.");
    }

    private void OnDrawGizmos()
    {
        if (holeCenter != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(holeCenter.position, holeDetectionRadius);
        }
    }
}
