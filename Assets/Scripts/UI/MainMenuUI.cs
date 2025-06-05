using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;

    private void Awake() {
        startButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainScene);
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
        Time.timeScale = 1f;
    }
}
