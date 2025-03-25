
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private AsteroidSO bigAsteroidSO;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private Transform player;

    [SerializeField] private float timer;

    private void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnInterval) {
            SpawnAsteroid();
            timer = 0f;
        }
    }

    private void SpawnAsteroid() {
        if (asteroidPrefabs.Length == 0 || player == null) return;

        Vector2 spawnPos = GetRandomEdgeSpawnPosition();
        int index = Random.Range(0, asteroidPrefabs.Length);
        float randomDegree = Random.Range(0, 359);
        GameObject asteroid = Instantiate(asteroidPrefabs[index], spawnPos, Quaternion.Euler(0,0, randomDegree) );

        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        if (rb != null) {
            Vector2 direction = (player.position - asteroid.transform.position).normalized;
            if(asteroid.GetComponent<Asteroid>().GetAsteroidSO() == bigAsteroidSO) {
                rb.linearVelocity = direction * Random.Range(1f, 2f);
            }
            else {
                rb.linearVelocity = direction * Random.Range(1f, 4f);
            }
            
        }
    }

    private Vector2 GetRandomEdgeSpawnPosition() {
        Camera cam = Camera.main;
        float screenBuffer = 2f; // Distance outside the screen

        Vector2 min = cam.ViewportToWorldPoint(new Vector3(0, 0));
        Vector2 max = cam.ViewportToWorldPoint(new Vector3(1, 1));

        int side = Random.Range(0, 4); // 0: left, 1: right, 2: top, 3: bottom
        switch (side) {
            case 0: // Left
                return new Vector2(min.x - screenBuffer, Random.Range(min.y, max.y));
            case 1: // Right
                return new Vector2(max.x + screenBuffer, Random.Range(min.y, max.y));
            case 2: // Top
                return new Vector2(Random.Range(min.x, max.x), max.y + screenBuffer);
            case 3: // Bottom
                return new Vector2(Random.Range(min.x, max.x), min.y - screenBuffer);
            default:
                return Vector2.zero;
        }
    }





}
