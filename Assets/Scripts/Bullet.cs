using UnityEngine;

public class Bullet : MonoBehaviour {
    IDmagebale damagebale;
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            if(other.gameObject.TryGetComponent<IDmagebale>(out damagebale)) {
                damagebale.TakeDamage();
            }
        }

    }
}
