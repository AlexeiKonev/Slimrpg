using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable {
    public int maxHealth = 20;
    public int enemyAttack = 2;
    public float moveSpeed = 4f;
    public float attackDistance = 1.5f;
    public float keepDistance = .2f;
    public Slider healthBar;
    public Text damageTextPrefab;

    private int currentHealth;
    private Transform playerTransform;
    private bool isAttacking;
    private float lastAttackTime;
    public Action<GameObject> OnDeath { get; internal set; }
    private void Start() {
        currentHealth = maxHealth;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        if (Vector3.Distance(transform.position, playerTransform.position) <= attackDistance && !isAttacking) {
            isAttacking = true;
        }

        if (isAttacking) {
            if (Time.time - lastAttackTime >= 1f) {
                if (Vector3.Distance(transform.position, playerTransform.position) <= attackDistance && Time.time - lastAttackTime >= 1f) {
                    playerTransform.GetComponent<IDamageable>().TakeDamage(enemyAttack);
                    lastAttackTime = Time.time;
                    Debug.Log($"lastAttackTime {lastAttackTime}");
                }


            }

            if (Vector3.Distance(transform.position, playerTransform.position) > attackDistance + 0.5f) {
                isAttacking = false;
            }
        }
        else {
            if (Vector3.Distance(transform.position, playerTransform.position) > keepDistance) {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
            transform.LookAt(playerTransform.position);
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
        else {
            if (currentHealth > 0) {
                healthBar.value = (float)currentHealth / maxHealth;
                ShowDamageText(damage);
            }

        }
    }

    private void Die() {
        SlimeGame.instance.AddMoney();// Add 
        Debug.Log($"enemy destroyd  ");
        Destroy(gameObject);
    }

    private void ShowDamageText(int damage) {
        var damageText = Instantiate(damageTextPrefab, transform.position + Vector3.up, Quaternion.identity);
        damageText.text = damage.ToString();
        Destroy(damageText.gameObject, 1f);
    }
}



//public class Enemy : MonoBehaviour, IDamageable {
//    public int health = 20;
//    public int enemyAttack = 2;
//    private bool canShoot = false;
//    private float delayAttack = 0.5f;
//    private Transform closestEnemy;
//    private bool enemyMov;
//    private float speed = 4f;
//    public Slider healthBar;
//    public GameObject damageTextPrefab;
//    public Transform healthBarPosition;
//    public Transform damageTextPosition;

//    public Action<GameObject> OnDeath { get; internal set; }

//    public void TakeDamage(int damage) {
//        if (health > 0) {
//            health -= damage;
//            healthBar.value = (float)health / 1000;
//            Debug.Log($"Enemy takes {damage} damage, health is {health}");

//            // Instantiate damage text above the enemy
//            GameObject damageText = Instantiate(damageTextPrefab, damageTextPosition.position, Quaternion.identity);
//            damageText.GetComponent<TextMesh>().text = "-" + damage.ToString();
//        }
//        else {
//            SlimeGame.instance.AddMoney();
//            Destroy(gameObject);
//        }
//    }

//    void Update() {
//        closestEnemy = FindEnemy();

//        if (closestEnemy != null && canShoot) {
//            StartCoroutine(ShootDelay());
//            ShootBullet(closestEnemy);
//        }
//        else {
//            enemyMov = true;
//        }

//        if (enemyMov) {
//            MoveToPlayer();
//        }
//    }

//    private void ShootBullet(Transform closestEnemy) {
//        if (closestEnemy.gameObject.TryGetComponent<IDamageable>(out IDamageable player)) {
//            player.TakeDamage(enemyAttack);
//        }
//    }

//    private IEnumerator ShootDelay() {
//        canShoot = false;
//        yield return new WaitForSeconds(delayAttack);
//        canShoot = true;
//    }

//    private Transform FindEnemy() {
//        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");

//        if (enemies.Length == 0) {
//            return null;
//        }

//        Transform nearestEnemy = enemies[0].transform;
//        float distanceForNearestEnemy = Vector3.Distance(nearestEnemy.transform.position, transform.position);
//        if (enemies.Length > 1) {
//            for (int i = 1; i < enemies.Length; i++) {
//                Transform currentEnemy = enemies[i].transform;
//                float distanceForCurrentEnemy = Vector3.Distance(currentEnemy.transform.position, transform.position);
//                if (distanceForCurrentEnemy < distanceForNearestEnemy) {
//                    distanceForNearestEnemy = distanceForCurrentEnemy;
//                    nearestEnemy = currentEnemy;
//                }
//            }
//        }

//        return nearestEnemy;
//    }

//    void MoveToPlayer() {
//        Vector3 direction = closestEnemy.position - transform.position;
//        float distanceThisFrame = speed * Time.deltaTime;
//        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

//        // Set health bar position above the enemy
//        healthBarPosition.position = transform.position + Vector3.up * 1.5f;
//    }

//    private void OnTriggerEnter(Collider other) {
//        if (other.gameObject.CompareTag("Player")) {
//            Debug.Log("Switch off moving enemy");
//            enemyMov = false;
//        }
//    }
//}

