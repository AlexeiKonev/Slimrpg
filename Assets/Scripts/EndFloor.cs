using UnityEngine;

public class EndFloor : MonoBehaviour {
    public GameObject newFloor;
    public Transform nextFloorPos;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"&& SlimeGame.instance.isAreaClear==true) {
            Instantiate(newFloor, nextFloorPos.position, Quaternion.identity);
            SlimeGame.instance.isAreaClear = false;
            Debug.Log("end detected");
        }
    }
}
