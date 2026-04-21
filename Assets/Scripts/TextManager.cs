using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TextManager : MonoBehaviour {
    
    [SerializeField]
    private Text personnalInventoryText, processedOreText, livesCountText, disconnectedText;

    [SerializeField]
    private GameObject disconnectedTextContainer;

    private bool hasStartedGameOver = false;

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
            livesCountText.text = "Robo-Miners Remaining: " + HealthModel.Instance.numberOfLives.ToString() + "/" + HealthModel.Instance.maxNumberOfLives.ToString();
        }

        if (disconnectedTextContainer != null) {
            disconnectedTextContainer.SetActive(!HealthModel.Instance.isConnected);
        }

        if (disconnectedText != null && !HealthModel.Instance.outOfLives) {
            disconnectedText.text = "Lost signal to Robo-Miner!\n There are " + HealthModel.Instance.numberOfLives + " remaining miners at home station.";
        }


        if (HealthModel.Instance.outOfLives && !hasStartedGameOver) {
            hasStartedGameOver = true;
            StartCoroutine(goToGameOver());
        }
    }


    IEnumerator goToGameOver() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName: "Gameover");
        yield return null;
    }   
}
