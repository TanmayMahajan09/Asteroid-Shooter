using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader {

    public enum Scene {
        MainScene,
        MainMenuScene,

    }

    public static Scene targetScene;

    public static void Load(Scene targetScene) {
        SceneManager.LoadScene(targetScene.ToString());

    }
}