using UnityEngine;

public class Bullet : MonoBehaviour {
    IDamageable damagebale;


    public float speed = 10f; // �������� ����
    public int damage; // ����, ������� ������� ����

    private Transform target; // ���� ���� (����)
    void Start() {

    }
    //private void HitTarget() {
    //    // ������� ���� �����
    //    EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
    //    if (enemyHealth != null) {
    //        enemyHealth.TakeDamage(damage);
    //    }

    //    // ���������� ����
    //    Destroy(gameObject);
    //}
    private void Update() {
        if (target == null) {
            // ���� ���� ���� ����������, ���������� � ����
            Destroy(gameObject);
            return;
        }

        // ����������� �������� ���� � ����
        Vector3 direction = target.position - transform.position;

        // ���������� �� ����
        float distanceThisFrame = speed * Time.deltaTime;

        
      

        // ���������� ���� � ����������� ����
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
    public void SetTarget(Transform enemyTransform) {
        target = enemyTransform; // ��������� ����
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










