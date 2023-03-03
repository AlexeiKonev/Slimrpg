using UnityEngine;

public class Bullet : MonoBehaviour {
    IDamageable damagebale;


    public float speed = 10f; // Скорость пули
    public int damage; // Урон, который наносит пуля

    private Transform target; // Цель пули (враг)
    void Start() {

    }
    //private void HitTarget() {
    //    // Наносим урон врагу
    //    EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
    //    if (enemyHealth != null) {
    //        enemyHealth.TakeDamage(damage);
    //    }

    //    // Уничтожаем пулю
    //    Destroy(gameObject);
    //}
    private void Update() {
        if (target == null) {
            // Если цель была уничтожена, уничтожаем и пулю
            Destroy(gameObject);
            return;
        }

        // Направление движения пули к цели
        Vector3 direction = target.position - transform.position;

        // Расстояние до цели
        float distanceThisFrame = speed * Time.deltaTime;

        
      

        // Перемещаем пулю в направлении цели
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
    public void SetTarget(Transform enemyTransform) {
        target = enemyTransform; // Установка цели
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            if (other.gameObject.TryGetComponent<IDamageable>(out damagebale)) {
                damagebale.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

    }
}










