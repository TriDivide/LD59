using UnityEngine;

public class AstroidSpawner : MonoBehaviour {
    
    [SerializeField] private GameObject asteroid;

    [SerializeField] private float spawnRepeatDelaySecs = 3f;
    [SerializeField] private float initialSpawnDelay = 5f;
    [SerializeField] private int maxNumberEntities = 10;

    void Start() {
        InvokeRepeating("SpawnAstroid", initialSpawnDelay, spawnRepeatDelaySecs);
    }


    private void SpawnAstroid() {
        if (asteroid != null) {
            if (GameObject.FindGameObjectsWithTag("Astroid").Length < maxNumberEntities) { 
                Instantiate(asteroid, transform.position, transform.rotation);
            }
        }
    }
}
