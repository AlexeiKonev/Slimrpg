using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable {
    [SerializeField] private int maxHealth = 50;
    public float regenRate = 10f; // скорость восстановления здоровья в единицах в секунду
    private int currentHealth;
    private float lastRegenTime;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
        lastRegenTime = Time.time;
        SlimeGame.instance.health = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        if (currentHealth < maxHealth) {
            if (Time.time - lastRegenTime >= 1f) {
                currentHealth++;
                lastRegenTime = Time.time;
                UpdateUI();
            }
        }
    }
    void UpdateUI() {
        healthSlider.value = (float)currentHealth / maxHealth;
    }
    public void TakeDamage(int damage) {
        if (currentHealth > 0) {
            currentHealth -= damage;
            Debug.Log($"player take {damage} health is {currentHealth}");
             
        }
        else {
            SlimeGame.instance.ShowGameOver();
           
        }
    }
}
