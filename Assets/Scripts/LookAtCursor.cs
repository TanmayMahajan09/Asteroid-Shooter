using UnityEngine;

public class LookAtCursor : MonoBehaviour {

    private bool IsGamePlaying = true;
    private void Start() {
        GameManager.instance.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.State e) {
        if (e == GameManager.State.GamePaused || e == GameManager.State.GameOver) {
            IsGamePlaying = false;
        }
    }

    public void LookAt(Vector3 targetVector) {
        float lookAngle = AngleBetweenPoints(transform.position, targetVector) + 90;
        if (IsGamePlaying) {
            transform.eulerAngles = new Vector3(0, 0, lookAngle);
        }

        }

    private float AngleBetweenPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y ,a.x - b.x) * Mathf.Rad2Deg;
    }

}
