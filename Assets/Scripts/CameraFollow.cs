using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // об'Їкт гравц€, за €ким сл≥дкуЇ камера
    public Vector3 offset; // в≥дстань м≥ж камерою та гравцем
    public Vector3 targetPosition; // позиц≥€, до €коњ камера повинна перем≥ститис€
    public float transitionTime = 2.0f; // час переходу
    private bool isMovingToTarget = false; // чи виконуЇтьс€ корутина

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            StartCoroutine(StartAfterDelay(1)); // «апускаЇмо корутину п≥сл€ затримки в 3 секунди
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

        // ѕерем≥щенн€ камери до targetPosition прот€гом 2 секунд
        while (t < transitionTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, targetPosition, t / transitionTime);
            yield return null;
        }

        yield return new WaitForSeconds(1); // «упинка камери на 1 секунду

        t = 0;
        startingPos = transform.position;

        // ѕоверненн€ камери до гравц€ прот€гом 2 секунд
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
