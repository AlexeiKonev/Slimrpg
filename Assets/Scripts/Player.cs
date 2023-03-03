using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable {
    [SerializeField]private int health = 50 ;


    // Start is called before the first frame update
    void Start()
    {
        SlimeGame.instance.health = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage) {
        if (health > 0) {
            health -= damage;
            Debug.Log($"player take {damage}health is{health}");
        }
}
}
 
    