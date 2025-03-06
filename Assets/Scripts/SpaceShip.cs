using UnityEngine;

public class SpaceShip : MonoBehaviour {

    //[SerializeField] private InputManager inputManager;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Vector3 newDirection;
    [SerializeField] private LookAtCursor lookAtCursor;
    private Vector2 mousePosition;
    private float interpolationTime = 0.3f;
    private Vector3 moveDirection;
    private Vector3 oldDirection = Vector3.zero ;

    private Rigidbody2D rb;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void Update() {
        HandleMovementInput();
        HandleLookAtCursor();
    }

    private void HandleLookAtCursor() {
        mousePosition = InputManager.Instance.GetMouseCursor();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        lookAtCursor.LookAt(mousePosition);
    }


    private void HandleMovementInput() {
        Vector2 normalisedMovementVector = InputManager.Instance.GetNormalisedMovementVector();
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