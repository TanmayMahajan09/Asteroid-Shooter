using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    [SerializeField] private PlayerInputActions playerInputActions;
    private Vector2 targetVector;
    public event EventHandler OnLMBPressed; 

    public static InputManager Instance {  get; private set; }
    private void Awake () {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void Start () {
        playerInputActions.Player.Fire.performed += Fire_performed;
    }

    private void Fire_performed(InputAction.CallbackContext obj) {
        OnLMBPressed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetNormalisedMovementVector() {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

    public Vector2 GetMouseCursor() {
        targetVector = playerInputActions.Player.Cursor.ReadValue<Vector2>();
        return targetVector;
    }

    
}