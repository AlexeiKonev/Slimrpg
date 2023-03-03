
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bulletPrefab;//ссылка на обьект пули
    public Transform shootPoint;
    public Transform enemyPoint;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            ShootBullet();
        }
    }

    private void ShootBullet() {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.damage = SlimeGame.instance.attack;//обращаемся к синглтону и задаем  силу атаки
    }
}
