using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable {
    [SerializeField] private int health = 50;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start() {
        SlimeGame.instance.health = health;
    }

    // Update is called once per frame
    void Update() {

    }

    public void TakeDamage(int damage) {
        if (health > 0) {
            health -= damage;
            Debug.Log($"player take {damage} health is {health}");
            healthBar.value = (float)health / 50f;
        }
        else {
            SlimeGame.instance.ShowGameOver();
           
        }
    }
}
