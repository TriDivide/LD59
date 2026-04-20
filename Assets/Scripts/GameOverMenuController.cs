using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenuController: MonoBehaviour {
    
    [SerializeField] private Text oreText;


    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;


    
    void Start() {
        oreText.text = "Total Ore processed: " + InventoryModel.Instance.baseInventory;
    }


    public void ReturnToStart() {
        source.PlayOneShot(clip);
        InventoryModel.Instance.Reset();
        HealthModel.Instance.reset();
        SceneManager.LoadScene(sceneName: "Main");
    }

    public void Quit() {
        source.PlayOneShot(clip);
        Application.Quit();
    }
}
