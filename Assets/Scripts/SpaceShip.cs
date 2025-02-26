using UnityEngine;

public class SpaceShip : MonoBehaviour {

    [SerializeField] private InputManager inputManager;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Vector3 newDirection;
    private float interpolationTime = 0.3f;
    private int movementIterator = 30;
    private Vector3 moveDirection;
    private Vector3 oldDirection = Vector3.zero ;
    private float smoothStep = Mathf.SmoothStep(5, 0, 0.5f);
    private Rigidbody2D rb;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        HandleMovementnput();
    }

    private void HandleMovementnput() {
        Vector2 normalisedMovementVector = inputManager.GetNormalisedMovementVector();
        moveDirection = new Vector3 (normalisedMovementVector.x, normalisedMovementVector.y, 0);
        newDirection = moveDirection;
        if(newDirection != oldDirection) {
            interpolationTime = 0.3f;
            oldDirection = newDirection;
        }
        

    }

    private void FixedUpdate() {
        rb.linearVelocity = Vector2.Lerp(rb.GetPointVelocity(this.transform.position), moveDirection * moveSpeed, interpolationTime * 10 * Time.deltaTime);
        
    }
}