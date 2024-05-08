using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ��'��� ������, �� ���� ����� ������
    public Vector3 offset; // ������� �� ������� �� �������

    void Update()
    {
        // ��������� ������� ������, �������������� ������� ������ �� �������
        Vector3 newPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.1f);
    }
}
