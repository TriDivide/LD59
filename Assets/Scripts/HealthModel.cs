using UnityEngine;

public class HealthModel {
    public static HealthModel Instance { get; private set; } = new HealthModel();


    public float currentRobotHealth { get; private set; }
    public int numberOfLives { get; private set; }

    private float maximumPlayerHealth = 100f;

    public HealthModel() {
        reset();
    }


    public void reset() {
        resetRobotHealth();
        numberOfLives = 3;
    }


    public void updateLives(int live) {
        if (numberOfLives > 0) {
            numberOfLives += live;
        }
        else {
            
        }
    }

    public void updateCurrentRobotHealth(float robotHealthUpdate) {
        if (currentRobotHealth < currentRobotHealth) {
        currentRobotHealth += robotHealthUpdate;
        Debug.Log(currentRobotHealth);
        }
        else {
            resetRobotHealth();
        }
    }

    public void resetRobotHealth() {
        currentRobotHealth = maximumPlayerHealth;
    }
}
