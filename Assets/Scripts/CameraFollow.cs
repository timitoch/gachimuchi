using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // об'Їкт гравц€, за €ким сл≥дкуЇ камера
    public Vector3 offset; // в≥дстань м≥ж камерою та гравцем

    void Update()
    {
        // ќновлюЇмо позиц≥ю камери, використовуючи позиц≥ю гравц€ та зм≥щенн€
        Vector3 newPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.1f);
    }
}
