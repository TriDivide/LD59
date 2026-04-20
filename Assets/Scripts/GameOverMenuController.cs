using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenuController: MonoBehaviour {
    
    [SerializeField] private Text oreText;


    
    void Start() {
        oreText.text = "Total Ore processed: " + InventoryModel.Instance.baseInventory;
    }


    public void ReturnToStart() {
        InventoryModel.Instance.Reset();
        HealthModel.Instance.reset();
        SceneManager.LoadScene(sceneName: "Main");
    }

    public void Quit() {
        Application.Quit();
    }
}
