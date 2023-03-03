using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target; // ������ �� ��������� ������, �� ������� ������ ������
    public float distance = 10f; // ���������� ������ �� ������ �� ��� Z
    public float height = 5f; // ������ ������ ��� �������
    public float smoothSpeed = 0.125f; // �������� ����������� ������

    private Vector3 offset; // ������ �������� ����� ������� � �������

    private void Start() {
        offset = transform.position - target.position; // ��������� ������ �������� ����� ������� � ������� ��� �������������
    }

    private void LateUpdate() {
        // ��������� ������� ������ �� ������ ������� ������ � ������� ��������
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.x, target.position.z+5f) + offset + Vector3.up * height - Vector3.forward * distance;

        // ������ ���������� ������ � �������� �������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // ���������� ������ �� ������
        //transform.LookAt(target.position + Vector3.up * height - Vector3.forward * 2f);
    }
}
