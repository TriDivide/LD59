using UnityEngine;
using UnityEngine.UI;

public class HealthSignalManager: MonoBehaviour {


    private GameObject homeBase, player;

    [SerializeField] private Image signalBar, healthBar;

    [SerializeField] private float maxDistance = 100f;


    [SerializeField] private GameObject signalWarning, spawnAnchor, deadRobot;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    [SerializeField] private AudioSource warningSource;

    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        homeBase = GameObject.FindGameObjectsWithTag("Base")[0];
        player = GameObject.FindGameObjectsWithTag("Player")[0];

        signalWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        Vector2 difference = new Vector2(homeBase.transform.position.x - player.transform.position.x, homeBase.transform.position.y - player.transform.position.y);

        float d = Mathf.Sqrt(Mathf.Pow(difference.x, 2f) + Mathf.Pow(difference.y, 2f));

        HealthModel.Instance.updateDistance((maxDistance - d) / maxDistance);

        signalBar.fillAmount = HealthModel.Instance.distance;

        
        bool showWarning = (HealthModel.Instance.distance < HealthModel.Instance.distanceWarning && HealthModel.Instance.isConnected);
        signalWarning.SetActive(showWarning);

        if (!warningSource.isPlaying) {
            if (showWarning) {
                warningSource.Play();
            }
        }
        else {
            if (!showWarning) {
                warningSource.Stop();
            }
        }
        healthBar.fillAmount = HealthModel.Instance.currentRobotHealth >= 0 ? (HealthModel.Instance.currentRobotHealth / 100f) : 0f;
    }

    public void Respawn() {
        source.PlayOneShot(clip);
        if (spawnAnchor != null & player != null) {
            Instantiate(deadRobot, player.transform.position, player.transform.rotation);

            player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            player.transform.position = spawnAnchor.transform.position;
            player.transform.rotation = Quaternion.identity;
            HealthModel.Instance.resetRobotHealth();
            HealthModel.Instance.setIsConnected(true);
        }
    }
}
