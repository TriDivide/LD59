using UnityEngine;
using UnityEngine.UI;

public class SignalStrengthManager : MonoBehaviour {


    private GameObject homeBase, player;

    [SerializeField] private Image signalBar;

    [SerializeField] private float maxDistance = 100f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        homeBase = GameObject.FindGameObjectsWithTag("Base")[0];
        player = GameObject.FindGameObjectsWithTag("Player")[0];

    }

    // Update is called once per frame
    void Update() {
        Vector2 difference = new Vector2(homeBase.transform.position.x - player.transform.position.x, homeBase.transform.position.y - player.transform.position.y);

        float d = Mathf.Sqrt(Mathf.Pow(difference.x, 2f) + Mathf.Pow(difference.y, 2f));

        signalBar.fillAmount = (maxDistance - d) / maxDistance;
    }
}
