using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
    
    public Text personnalInventoryText, processedOreText, livesCountText;

    void Start() {
        InventoryModel.Instance.addToLocalInventory(0);
    }

    
    void Update() {
        if (personnalInventoryText != null) {
            personnalInventoryText.text = "Ore collected: " + InventoryModel.Instance.playerInventory.ToString() + "/" + InventoryModel.Instance.maxPlayerInventory.ToString();
        }

        if (processedOreText != null) {
            processedOreText.text = "Ore processed: " + InventoryModel.Instance.baseInventory.ToString();
        }
        
        if (livesCountText != null) {
            livesCountText.text = "Mine-Bots Remaining: " + HealthModel.Instance.numberOfLives.ToString() + "/" + HealthModel.Instance.maxNumberOfLives.ToString();
        }
    }
}
