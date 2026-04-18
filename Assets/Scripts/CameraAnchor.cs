using UnityEngine;

public class CameraAnchor : MonoBehaviour {

    private GameObject target;

    private float distance;


    void Start() {
        target = GameObject.FindGameObjectsWithTag("Player")[0];

        distance = transform.position.z;
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, distance);
    }
}
