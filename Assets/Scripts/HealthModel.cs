using UnityEngine;


public class HealthModel {
    public static HealthModel Instance { get; private set; } = new HealthModel();


    public float currentRobotHealth { get; private set; }
    public int numberOfLives { get; private set; }

    private float maximumPlayerHealth = 100f;
    public int maxNumberOfLives {get; private set; } = 3;

    public float distance { get; private set; }

    public float distanceWarning { get; private set; }

    public bool isConnected { get; private set; }

    public bool outOfLives { get; private set; }


    public HealthModel() {
        reset();
        distance = 1f;
        distanceWarning = 0.2f;
    }

    public void setIsConnected(bool newValue) {
        isConnected = newValue;
    }


    public void reset() {
        resetRobotHealth();
        numberOfLives = maxNumberOfLives;
        outOfLives = false;
    }


    public void updateLives(int live) {
        if (numberOfLives > 0) {
            numberOfLives += live;
            if (live < 0) {
                resetRobotHealth();
            }
        }
        else {
            outOfLives = true;
        }
    }

    public void updateDistance(float distance) {
        this.distance = distance;
    }

    public void updateCurrentRobotHealth(float robotHealthUpdate) {
        if (robotHealthUpdate > 0 && currentRobotHealth == maximumPlayerHealth) {
            return;
        }
        if (currentRobotHealth <= maximumPlayerHealth) {
            currentRobotHealth += robotHealthUpdate;
            if (currentRobotHealth <= 0 && isConnected) {
                setIsConnected(false);
                updateLives(-1);
            }
        }
        else {
            resetRobotHealth();
        }
    }

    public void resetRobotHealth() {
        currentRobotHealth = maximumPlayerHealth;
    }
}
