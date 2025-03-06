using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] private Transform firePoint;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject bulletPrefab;
    private bool LMBIsHeld = false;
    private float fireCooldown = 0.5f;
    private float fireTimer;

    private void Awake() {
        fireTimer = fireCooldown;
    }
    private void Start() {
        inputManager.OnLMBPressed += InputManager_OnLMBPressed;
        
    }

    private void Update() {
        fireTimer += Time.deltaTime;
        if(LMBIsHeld) {
            if(fireTimer >= fireCooldown) {
                Shoot();
                fireTimer = 0f;
            }
        }
    }

    private void InputManager_OnLMBPressed(object sender, System.EventArgs e) {
        LMBIsHeld = !LMBIsHeld;
    }

    private void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}