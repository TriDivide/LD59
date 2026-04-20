using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
    
    [SerializeField]
    private Text personnalInventoryText, processedOreText, livesCountText, disconnectedText;

    [SerializeField]
    private GameObject disconnectedTextContainer;

    void Start() {
        InventoryModel.Instance.addToLocalInventory(0);
        disconnectedTextContainer.SetActive(false);
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

        if (disconnectedTextContainer != null) {
            disconnectedTextContainer.SetActive(!HealthModel.Instance.isConnected);
        }

        if (disconnectedText != null) {
            disconnectedText.text = "Lost signal to Astro-Miner!\n There are " + HealthModel.Instance.numberOfLives + " remaining miners at home station.";
        }
    }
}
