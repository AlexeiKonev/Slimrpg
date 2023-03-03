using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class Enemy : MonoBehaviour, IDamageable {
    public int health = 20;
    public int enemyAttack = 2;
    private bool canShoot = false;
    private float delayAttack = 0.5f;
    private Transform closestEnemy;
    private bool enemyMov;
    private float speed = 4f;
    public Slider healthBar;
    public GameObject damageTextPrefab;
    public Transform healthBarPosition;
    public Transform damageTextPosition;

    public Action<GameObject> OnDeath { get; internal set; }

    public void TakeDamage(int damage) {
        if (health > 0) {
            health -= damage;
            healthBar.value = (float)health / 1000;
            Debug.Log($"Enemy takes {damage} damage, health is {health}");

            // Instantiate damage text above the enemy
            GameObject damageText = Instantiate(damageTextPrefab, damageTextPosition.position, Quaternion.identity);
            damageText.GetComponent<TextMesh>().text = "-" + damage.ToString();
        }
        else {
            SlimeGame.instance.AddMoney();
            Destroy(gameObject);
        }
    }

    void Update() {
        closestEnemy = FindEnemy();

        if (closestEnemy != null && canShoot) {
            StartCoroutine(ShootDelay());
            ShootBullet(closestEnemy);
        }
        else {
            enemyMov = true;
        }

        if (enemyMov) {
            MoveToPlayer();
        }
    }

    private void ShootBullet(Transform closestEnemy) {
        if (closestEnemy.gameObject.TryGetComponent<IDamageable>(out IDamageable player)) {
            player.TakeDamage(enemyAttack);
        }
    }

    private IEnumerator ShootDelay() {
        canShoot = false;
        yield return new WaitForSeconds(delayAttack);
        canShoot = true;
    }

    private Transform FindEnemy() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");

        if (enemies.Length == 0) {
            return null;
        }

        Transform nearestEnemy = enemies[0].transform;
        float distanceForNearestEnemy = Vector3.Distance(nearestEnemy.transform.position, transform.position);
        if (enemies.Length > 1) {
            for (int i = 1; i < enemies.Length; i++) {
                Transform currentEnemy = enemies[i].transform;
                float distanceForCurrentEnemy = Vector3.Distance(currentEnemy.transform.position, transform.position);
                if (distanceForCurrentEnemy < distanceForNearestEnemy) {
                    distanceForNearestEnemy = distanceForCurrentEnemy;
                    nearestEnemy = currentEnemy;
                }
            }
        }

        return nearestEnemy;
    }

    void MoveToPlayer() {
        Vector3 direction = closestEnemy.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

        // Set health bar position above the enemy
        healthBarPosition.position = transform.position + Vector3.up * 1.5f;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Switch off moving enemy");
            enemyMov = false;
        }
    }
}

