using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField] private PlayerInputActions playerInputActions;
    public static InputManager Instance {  get; private set; }
    private void Awake () {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetNormalisedMovementVector() {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

}