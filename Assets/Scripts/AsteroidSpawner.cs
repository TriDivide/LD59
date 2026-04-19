using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    
    [SerializeField] private GameObject asteroid;

    [SerializeField] private float spawnRepeatDelaySecs = 3f;
    [SerializeField] private float initialSpawnDelay = 5f;
    [SerializeField] private int maxNumberEntities = 10;

    void Start() {
        InvokeRepeating("SpawnAsteroid", initialSpawnDelay, spawnRepeatDelaySecs);
    }


    private void SpawnAsteroid() {
        if (asteroid != null) {
            if (GameObject.FindGameObjectsWithTag("Asteroid").Length < maxNumberEntities) { 
                Instantiate(asteroid, transform.position, transform.rotation);
            }
        }
    }
}
