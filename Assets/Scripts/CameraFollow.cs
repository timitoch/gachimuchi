using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ��'��� ������, �� ���� ����� ������
    public Vector3 offset; // ������� �� ������� �� �������
    public Vector3 targetPosition; // �������, �� ��� ������ ������� ������������
    public float transitionTime = 2.0f; // ��� ��������
    private bool isMovingToTarget = false; // �� ���������� ��������

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            StartCoroutine(StartAfterDelay(1)); // ��������� �������� ���� �������� � 3 �������
        }
    }

    IEnumerator StartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        isMovingToTarget = true;
        float t = 0;
        Vector3 startingPos = transform.position;

        // ���������� ������ �� targetPosition �������� 2 ������
        while (t < transitionTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, targetPosition, t / transitionTime);
            yield return null;
        }

        yield return new WaitForSeconds(1); // ������� ������ �� 1 �������

        t = 0;
        startingPos = transform.position;

        // ���������� ������ �� ������ �������� 2 ������
        while (t < transitionTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, player.position + offset, t / transitionTime);
            yield return null;
        }

        isMovingToTarget = false;
    }

    void Update()
    {
        if (!isMovingToTarget && transform.position != player.position + offset)
        {
            Vector3 newPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, newPosition, 0.1f);
        }
    }
}
