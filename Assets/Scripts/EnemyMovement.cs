using UnityEngine;


public class EnemyMovement : MonoBehaviour {
    public float speed = 3f;
    public float attackRange = 1f;
    public float attackDelay = 1f;
    public int damage = 10;

    private Transform player;
    private bool isAttacking = false;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {



        if (!isAttacking) {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer() {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.LookAt(player);
        if (Vector3.Distance(transform.position, player.position) <= attackRange) {
            isAttacking = true;
            InvokeRepeating("Attack", 0f, attackDelay);
        }
    }

    private void Attack() {
        if (Vector3.Distance(transform.position, player.position) <= attackRange) {
            player.GetComponent<Player >().TakeDamage(damage);
        }
        else {
            isAttacking = false;
            CancelInvoke("Attack");
        }
    }
}
