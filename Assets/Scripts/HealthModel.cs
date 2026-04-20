using UnityEngine;

public class HealthModel {
    public static HealthModel Instance { get; private set; } = new HealthModel();


    public float currentRobotHealth { get; private set; }
    public int numberOfLives { get; private set; }

    private float maximumPlayerHealth = 100f;
    public int maxNumberOfLives {get; private set; } = 3;

    public HealthModel() {
        reset();
    }


    public void reset() {
        resetRobotHealth();
        numberOfLives = maxNumberOfLives;
    }


    public void updateLives(int live) {
        if (numberOfLives > 0) {
            numberOfLives += live;
            if (live < 0) {
                resetRobotHealth();
            }
        }
        else {
            
        }
    }

    public void updateCurrentRobotHealth(float robotHealthUpdate) {
        if (robotHealthUpdate > 0 && currentRobotHealth == maximumPlayerHealth) {
            return;
        }
        if (currentRobotHealth <= maximumPlayerHealth) {
            currentRobotHealth += robotHealthUpdate;
        }
        else {
            resetRobotHealth();
        }
    }

    public void resetRobotHealth() {
        currentRobotHealth = maximumPlayerHealth;
    }
}
