using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bulletPrefab;//ссылка на обьект пули
    public Transform shootPoint;
    public float delayAttack = 20f;
    public bool canShoot = true;
    public Transform closestEnemy;
   public PlayerMovement playerMov;
    private void Update() {
       
        closestEnemy = FindEnemy();

        if (closestEnemy != null && canShoot) {

            StartCoroutine(ShootDelay());
            ShootBullet(closestEnemy);
        }
        else {
            playerMov.isMoving = true;
        }
    }

 public void   ChangeDelay(float someValue) {
        delayAttack -= someValue  ;
    }
    private Transform FindEnemy() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0) {
            SlimeGame.instance.isAreaClear = true;
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



    private IEnumerator ShootDelay() {



        canShoot = false; // запрещаем стрельбу
        yield return new WaitForSeconds(delayAttack);
        canShoot = true; // разрешаем стрельбу
    }

    private void ShootBullet(Transform enemyPoint) {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.damage = SlimeGame.instance.attack;
        bulletComponent.SetTarget(enemyPoint);
    }

}
