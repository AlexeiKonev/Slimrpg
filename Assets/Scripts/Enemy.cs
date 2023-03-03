using Slime;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour, IDmagebale {
    int health = 20;
    int enemyAttack =2;
    private bool canShoot =false;
    private float delayAttack =0.5f;
    private Transform closestEnemy;
    private bool EnemyMov;
    private float speed =4f;
    public Slider healthbar;

    public Action<GameObject> OnDeath { get; internal set; }

    public void TakeDamage(int damage) {
        if (health > 0) {
            health -= damage;
            healthbar.value =(float) health/1000;
            Debug.Log($"enemy take {damage}health is{health}");
        }
        else {
            SlimeGame.instance.AddMoney();
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        closestEnemy = FindEnemy();

        if (closestEnemy != null && canShoot) {

            StartCoroutine(ShootDelay());
            ShootBullet(closestEnemy);
        }
        else {
            EnemyMov = true;
        }

        if (EnemyMov) {
            MoveToPlayer();
        }
        

    }

    private void ShootBullet(Transform closestEnemy) {
      if(  closestEnemy.gameObject.TryGetComponent<IDmagebale>(out IDmagebale player)){
            player.TakeDamage(enemyAttack);
        }
    }

    private IEnumerator ShootDelay() {



        canShoot = false; // запрещаем стрельбу
        yield return new WaitForSeconds(delayAttack);
        canShoot = true; // разрешаем стрельбу
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
        //if (target == null) {
        //    // Если цель была уничтожена, уничтожаем и пулю
        //    Destroy(gameObject);
        //    return;
        //}

        // Направление движения пули к цели
        Vector3 direction = closestEnemy.position - transform.position;

        // Расстояние до цели
        float distanceThisFrame = speed * Time.deltaTime;




        // Перемещаем пулю в направлении цели
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("switchoff moving enemy");
            EnemyMov = false;
        }
    }
}

