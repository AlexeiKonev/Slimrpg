﻿using UnityEngine;
namespace Slime {


    public class PlayerHealth : MonoBehaviour {
        public int maxHealth = 100;
        public int currentHealth = 20;

        public HealthBar healthBar;

        void Start() {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        public void TakeDamage(int damage) {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0) {
                Die();
            }
        }

        void Die() {
             
        }
    }

}