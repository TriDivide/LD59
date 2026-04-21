using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuController: MonoBehaviour {
    
    public void StartGame() {
        SceneManager.LoadScene(sceneName: "Main");
    }

    public void Quit() {
        Application.Quit();
    }
}
