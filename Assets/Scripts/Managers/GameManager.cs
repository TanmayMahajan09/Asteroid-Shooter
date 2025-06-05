using System;
using UnityEngine;

public class GameManager : MonoBehaviour{
   
    public static GameManager instance { get; private set; }

    public event EventHandler<State> OnGameStateChanged;

    public enum State {
        WaitingToStart,
        GamePaused,
        GamePlaying,
        GameOver,
    }
    private State state;


    private void Awake() {
        instance = this;
        state = State.GamePlaying;
    }

    private void Start() {
        SpaceShip.instance.OnGameOver += SpaceShip_OnGameOver;
    }

    private void SpaceShip_OnGameOver(object sender, System.EventArgs e) {
        state = State.GameOver;
        Time.timeScale = 0f;
        OnGameStateChanged?.Invoke(this, state);
    }

    

}
