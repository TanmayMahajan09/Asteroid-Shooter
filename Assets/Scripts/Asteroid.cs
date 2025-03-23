using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField] private AsteroidSO asteroidSO;
    private float health;
    private float deathTimer;

    private void Start() {
        health = asteroidSO.health;
    }

    private void Update() {
        deathTimer += Time.deltaTime;
        if (deathTimer >= 20) {
            Die();
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
        Debug.Log(health);
        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }

}
