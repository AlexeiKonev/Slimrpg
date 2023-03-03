using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDmagebale {
    int health = 10;

    public Action<GameObject> OnDeath { get; internal set; }

    public void TakeDamage(int damage) {
        if (health > 0) {
            health -= damage;
            Debug.Log($"enemy take {damage}health is{health}");
        }
        else {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
