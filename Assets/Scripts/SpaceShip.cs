using System;
using UnityEngine;

public class SpaceShip : MonoBehaviour {

    
    public static SpaceShip instance { get; private set; }

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Vector3 newDirection;
    [SerializeField] private LookAtCursor lookAtCursor;
    [SerializeField] private float maxHealth = 100f;
    private float health;
    private Vector2 mousePosition;
    private float interpolationTime = 0.3f;
    private Vector3 moveDirection;
    private Vector3 oldDirection = Vector3.zero ;

    public event EventHandler<float> OnHit;
    public event EventHandler OnGameOver;

    private Rigidbody2D rb;
    private void Awake() {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
       
    }
    private void Start() {
        health = maxHealth;
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

    public void TakeDamage(float damage) {
        health -= damage;
        OnHit?.Invoke(this, health);
        Debug.Log(health);
        if(health <= 0) {
            Debug.Log("Game Over");
            OnGameOver?.Invoke(this, EventArgs.Empty);
        }
    }

    public float GetMaxHealth() {
        return maxHealth;
    }
}