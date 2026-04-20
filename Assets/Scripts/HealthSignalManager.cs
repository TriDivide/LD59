using UnityEngine;
using UnityEngine.UI;

public class HealthSignalManager: MonoBehaviour {


    private GameObject homeBase, player;

    [SerializeField] private Image signalBar, healthBar;

    [SerializeField] private float maxDistance = 100f;

    [SerializeField] private GameObject signalWarning;


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

        float fillAmount = (maxDistance - d) / maxDistance;

        signalBar.fillAmount = fillAmount;

        signalWarning.SetActive(fillAmount < 0.2f);
        

        healthBar.fillAmount = HealthModel.Instance.currentRobotHealth >= 0 ? (HealthModel.Instance.currentRobotHealth / 100f) : 0f;
    }
}
