using UnityEngine;

public class DeadRobotController : MonoBehaviour {
    
    [SerializeField] private float minRotationSpeed, maxRotationSpeed, minSpeed, maxSpeed;

    [SerializeField] private Rigidbody2D rb;

    void Start() {
        minRotationSpeed = 10.0f;
        maxRotationSpeed = 100.0f;

        minSpeed = 1f;
        maxSpeed = 10f;

        StartRotation();
        StartMovement();
    }

    private void StartRotation() {
        if (rb != null) {
            float spin = Random.Range(minRotationSpeed, maxRotationSpeed);

            if (Random.value > 0.5f) {
                spin *= -1f;
            }

            rb.angularVelocity = spin;
        }
    }

    private void StartMovement() {
        Vector2 direction = Random.insideUnitCircle.normalized;

        float force = Random.Range(minSpeed, maxSpeed);
        rb.AddForce(direction * force, ForceMode2D.Impulse);
        
    }
}
