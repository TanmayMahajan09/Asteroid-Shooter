using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float destroyTimer = 10f;
    [SerializeField] private float damage = 20f;

    private void Start() {
        rb.linearVelocity = transform.up * projectileSpeed;
    }

    private void Update() {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0f) { 
            Destroy(gameObject);  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.GetComponent<Asteroid>()!= null) {
            Asteroid hitAsteroid = collision.GetComponent<Asteroid>();
            if (hitAsteroid != null) {
                hitAsteroid.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        
    }

}