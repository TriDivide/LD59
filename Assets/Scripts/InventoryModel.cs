using UnityEngine;

public class InventoryModel {

    public static InventoryModel Instance { get; private set; } = new InventoryModel();


    public int playerInventory { get; private set; }
    public int baseInventory { get; private set; }

    public int maxPlayerInventory {get; private set; } 

    public InventoryModel() {
        playerInventory = 0;
        baseInventory = 0;

        maxPlayerInventory = 5;
    }

    public void Reset() {
        playerInventory = 0;
        baseInventory = 0;

        maxPlayerInventory = 5;
    }


    public void addToLocalInventory(int value) {
        if (playerInventory < maxPlayerInventory) {
            playerInventory += value;
        }
        else {
            playerInventory = maxPlayerInventory;
        }
    }

    public void transferToBaseInventory(int value) {
        int currentInventory = baseInventory;
        if (playerInventory > 0) {
            playerInventory -= value;
            baseInventory += value;
        }
        else {
            playerInventory = 0;
            baseInventory = currentInventory;
        }
        
    }
}
 