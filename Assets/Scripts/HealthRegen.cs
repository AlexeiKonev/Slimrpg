using UnityEngine;
using UnityEngine.UI;

public class HealthRegen: MonoBehaviour {
    public Slider healthSlider;
    public int maxHealth = 50;
    public float regenRate = 10f; // скорость восстановления здоровья в единицах в секунду
    private int currentHealth;
    private float lastRegenTime;

    void Start() {
        currentHealth = maxHealth;
        lastRegenTime = Time.time;
        UpdateUI();
    }

    void Update() {
        if (currentHealth < maxHealth) {
            if (Time.time - lastRegenTime >= 1f) {
                currentHealth++;
                lastRegenTime = Time.time;
                UpdateUI();
            }
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth < 0) {
            currentHealth = 0;
        }
        UpdateUI();
    }

    void UpdateUI() {
        healthSlider.value = (float)currentHealth / maxHealth;
    }
}
