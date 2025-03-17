using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField] private AsteroidSO asteroidSO;
    private float health;
    private Sprite asteroidSprite;

    private void Start() {
        health = asteroidSO.health;
        asteroidSprite = asteroidSO.sprite;
        gameObject.GetComponent<SpriteRenderer>().sprite = asteroidSprite;
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
