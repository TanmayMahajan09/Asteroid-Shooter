using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField] private AsteroidSO asteroidSO;
    private float health;
    private float deathTimer;
    private bool damageGiven = false;

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

    public AsteroidSO GetAsteroidSO() {
        return asteroidSO;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Ship hit");
        if (collision.GetComponent<SpaceShip>() != null) {
            SpaceShip spaceShip = collision.GetComponent<SpaceShip>();
            
            if (!damageGiven) {
                spaceShip.TakeDamage(20f);
                damageGiven = true;
            }
        }
    }

}
