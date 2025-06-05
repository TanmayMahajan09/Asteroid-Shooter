using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour{

    [SerializeField] Button restartButton;
    private void Awake() {
        restartButton.onClick.AddListener(() => {
            Time.timeScale = 1f;
            Loader.Load(Loader.Scene.MainScene);
        });
    }

    private void SpaceShip_OnGameOver(object sender, System.EventArgs e) {
        Show();
    }

    private void Start() {
        SpaceShip.instance.OnGameOver += SpaceShip_OnGameOver;
        Hide();
    }

    private void Show() {
        this.gameObject.SetActive(true);
    }

    private void Hide() {
        this.gameObject.SetActive(false);
    }

}
