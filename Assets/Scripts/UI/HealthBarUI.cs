using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private SpaceShip spaceShip;
    [SerializeField] private Image healthBar;

    public static HealthBarUI Instance { get; private set; }

    private void Awake(){
        Instance = this;
    }

    private void Start() {
        spaceShip.OnHit += SpaceShip_OnHit;
    }

    private void SpaceShip_OnHit(object sender, float e) {
        healthBar.fillAmount = e/spaceShip.GetMaxHealth();
    }
}
