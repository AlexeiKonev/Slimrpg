using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bulletPrefab;//������ �� ������ ����
    public Transform shootPoint;
    public float delayAttack = 2f;
    //public Transform enemyPoint;

    public GameObject closestEnemy;


    private void Update() {
        //if (Input.GetButtonDown("Fire1")) {
        //    ShootBullet();
        //}
        Transform closestEnemy = FindEnemy();

        if (closestEnemy != null) {
            StartCoroutine(ShootDelay());
            ShootBullet(closestEnemy);


        }

    }

    private void ShootBullet(Transform enemyPoint) {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.damage = SlimeGame.instance.attack;//���������� � ��������� � ������  ���� �����
        bulletComponent.SetTarget(enemyPoint);//���������� � ��������� � ������  ���� �����
    }


    private Transform FindEnemy() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
            return null;

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

    IEnumerator ShootDelay() {

        yield return new WaitForSeconds(delayAttack);
    }
}
