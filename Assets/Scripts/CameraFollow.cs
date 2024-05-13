using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ��'��� ������, �� ���� ����� ������
    public Vector3 offset; // ������� �� ������� �� �������
    public Vector3 targetPositionLevel1; // �������, �� ��� ������ ������� ������������ �� ��� 1
    public Vector3 targetPositionLevel2; // �������, �� ��� ������ ������� ������������ �� ��� 2
    public float transitionTimeLevel1 = 2.0f; // ��� �������� �� ��� 1
    public float transitionTimeLevel2 = 2.0f; // ��� �������� �� ��� 2
    public float cameraSizeLevel1 = 5.0f; // ����� ������ �� ��� 1
    public float cameraSizeLevel2 = 7.0f; // ����� ������ �� ��� 2
    private bool isMovingToTarget = false; // �� ���������� ��������

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Camera.main.orthographicSize = cameraSizeLevel1;
            StartCoroutine(StartAfterDelay(1, targetPositionLevel1, transitionTimeLevel1)); // ��������� �������� ���� �������� � 1 �������
        }

        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            Camera.main.orthographicSize = cameraSizeLevel2;
            StartCoroutine(StartAfterDelay(1, targetPositionLevel2, transitionTimeLevel2));
        }
    }

    IEnumerator StartAfterDelay(float delay, Vector3 targetPosition, float transitionTime)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveToTarget(targetPosition, transitionTime));
    }

    IEnumerator MoveToTarget(Vector3 targetPosition, float transitionTime)
    {
        isMovingToTarget = true;
        float t = 0;
        Vector3 startingPos = transform.position;

        // ���������� ������ �� targetPosition �������� �������� ����
        while (t < transitionTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, targetPosition, t / transitionTime);
            yield return null;
        }

        yield return new WaitForSeconds(1); // ������� ������ �� 1 �������

        t = 0;
        startingPos = transform.position;

        // ���������� ������ �� ������ �������� �������� ����
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
