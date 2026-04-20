using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    
    [SerializeField] private GameObject asteroid, mediumAsteroid;

    [SerializeField] private float spawnRepeatDelaySecs = 3f;
    [SerializeField] private float initialSpawnDelay = 5f;
    [SerializeField] private int maxNumberSmallEntities = 50;
    [SerializeField] private int maxNumberMediumEntities = 20;

    void Start() {
        InvokeRepeating("SpawnAsteroid", initialSpawnDelay, spawnRepeatDelaySecs);
    }


    private void SpawnAsteroid() {
        if (asteroid != null && mediumAsteroid != null) {

            if(Random.value <= 0.25) {
                if (GameObject.FindGameObjectsWithTag("MediumAsteroid").Length < maxNumberMediumEntities) { 
                    Instantiate(mediumAsteroid, transform.position, transform.rotation);
                }
            }
            else {
                if (GameObject.FindGameObjectsWithTag("Asteroid").Length < maxNumberSmallEntities) { 
                    Instantiate(asteroid, transform.position, transform.rotation);
                }
            }

        }
    }
}
