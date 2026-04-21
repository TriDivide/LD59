using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Params")]
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float maxVelocity = 10f;
    [SerializeField] private float rotationSpeed = 180f;

    [Header("Sounds")]
    [SerializeField] private AudioSource depositSource, moveSource, collideSource, disconnectSource, mineSource, regenSource;
    [SerializeField] private AudioClip depositClip, collideClip, disconnectClip, mineClip, regenClip;



    private bool isAccelerating = false;
    private bool isReversing = false;

    private bool isBraking = false;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { 
        rb = GetComponent<Rigidbody2D>();
        HealthModel.Instance.setIsConnected(true);
    }

    // Update is called once per frame
    void Update() {  
        if (HealthModel.Instance.isConnected) {
            HandleAcceleration();
            HandleRotation();
            HandleDistance();
        }


    }


    private void FixedUpdate() {
        bool isAlive = HealthModel.Instance.isConnected;
        if (isAlive && isAccelerating) {
            rb.AddForce(acceleration * transform.up);
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxVelocity);
        }

        if (isAlive && isReversing) {
            rb.AddForce(-(acceleration/2) * transform.up);
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxVelocity/2);
        }

        if (isAlive && isBraking && (!isAccelerating || !isReversing)) {
            rb.linearVelocity *= 0.95f;
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxVelocity);
        }

        if (!isAlive) {
            rb.constraints = RigidbodyConstraints2D.None;
        }


    }


    private void HandleAcceleration() {
        isAccelerating = Input.GetKey(KeyCode.UpArrow);
        isReversing = Input.GetKey(KeyCode.DownArrow);
        isBraking = Input.GetKey(KeyCode.Space);


    }

    private void HandleRotation() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(rotationSpeed * Time.deltaTime * transform.forward);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(-rotationSpeed * Time.deltaTime * transform.forward);
        }
    }

    private void HandleDistance() {
        if (HealthModel.Instance.distance <= 0) {
            HealthModel.Instance.updateLives(-1);
            HealthModel.Instance.setIsConnected(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (HealthModel.Instance.isConnected) {
            if(collision.GetType() == typeof(CircleCollider2D) && collision.gameObject.tag == "Asteroid") {
                if (InventoryModel.Instance.playerInventory < InventoryModel.Instance.maxPlayerInventory) {
                    Destroy(collision.gameObject);
                    mineSource.PlayOneShot(mineClip);
                    InventoryModel.Instance.addToLocalInventory(1);
                }
                else {
                    collideSource.PlayOneShot(collideClip);
                    HealthModel.Instance.updateCurrentRobotHealth(-20);
                    if (!HealthModel.Instance.isConnected) {
                        disconnectSource.PlayOneShot(disconnectClip);
                    }
                }
            }

            if (collision.gameObject.tag == "MediumAsteroid") {
                collideSource.PlayOneShot(collideClip);
                HealthModel.Instance.updateCurrentRobotHealth(-40);
                    if (!HealthModel.Instance.isConnected) {
                        disconnectSource.PlayOneShot(disconnectClip);
                    }
            }

            if (collision.GetType() == typeof(BoxCollider2D) && collision.gameObject.tag == "Base") {
                InvokeRepeating("DepositOreRoutine", 0f, 0.5f);
                InvokeRepeating("RestoreHealth", 1f, 0.5f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetType() == typeof(BoxCollider2D) && collision.gameObject.tag == "Base") {
            regenSource.Stop();
            depositSource.Stop();

            CancelInvoke("DepositOreRoutine");
            CancelInvoke("RestoreHealth");
        }
    }




    private void DepositOreRoutine() {
        //depositSource.PlayOneShot(depositClip);
        InventoryModel.Instance.transferToBaseInventory(1);
    }

    private void RestoreHealth() {
       // regenSource.PlayOneShot(regenClip);
        HealthModel.Instance.updateCurrentRobotHealth(+10);
    }
}
