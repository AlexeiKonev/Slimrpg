using UnityEngine;

public class Enemy : MonoBehaviour, IDmagebale {
    int health = 10;

    public void TakeDamage() {
        health -= 2;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
