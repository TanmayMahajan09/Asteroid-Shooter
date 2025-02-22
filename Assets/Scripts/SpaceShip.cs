using UnityEngine;

public class SpaceShip : MonoBehaviour {

    [SerializeField] private InputManager inputManager;
    [SerializeField] private float moveSpeed = 5f;
    private void Awake() {
        
    }

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        
        Vector2 normalisedMovementVector = inputManager.GetNormalisedMovementVector();
        Vector3 moveDirection = new Vector3 (normalisedMovementVector.x, normalisedMovementVector.y, 0);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}