using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target; // —сылка на трансформ игрока, за которым следит камера
    public float distance = 10f; // –ассто€ние камеры до игрока по оси Z
    public float height = 5f; // ¬ысота камеры над игроком
    public float smoothSpeed = 0.125f; // —корость перемещени€ камеры

    private Vector3 offset; // ¬ектор смещени€ между камерой и игроком

    private void Start() {
        offset = transform.position - target.position; // ¬ычисл€ем вектор смещени€ между камерой и игроком при инициализации
    }

    private void LateUpdate() {
        // ¬ычисл€ем позицию камеры на основе позиции игрока и вектора смещени€
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.x, target.position.z+5f) + offset + Vector3.up * height - Vector3.forward * distance;

        // ѕлавно перемещаем камеру к желаемой позиции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Ќаправл€ем камеру на игрока
        //transform.LookAt(target.position + Vector3.up * height - Vector3.forward * 2f);
    }
}
