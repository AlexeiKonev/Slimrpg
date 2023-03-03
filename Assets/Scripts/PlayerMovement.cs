using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5f;
    public float stoppingDistance = 2f;

    public Shoot shoot;
    [SerializeField] private Transform target;
    public bool isMoving = true;

    void Start() {
        target = GameObject.FindGameObjectWithTag("stop").transform;
    }

    void Update() {

        if (isMoving && SlimeGame.instance.isAreaClear == true) {
            transform.position += transform.forward * speed * Time.deltaTime;
            //animator.SetBool("isMoving", true);
            //isMoving = true;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("stop") && SlimeGame.instance.isAreaClear == false) {
            Debug.Log("player stop");
            isMoving = false;


        }


    }
}
