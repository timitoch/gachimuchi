using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] items;
    public Transform spawnPoint;
    public float spawnRadius = 1f;
    public float closeDelay = 1f; // Затримка перед закриттям сундука

    private bool isOpen = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isOpen)
        {
            if (Vector2.Distance(transform.position, Player.Instance.transform.position) <= spawnRadius)
            {
                animator.SetTrigger("chest");
                SpawnRandomItem();
                isOpen = true;
                StartCoroutine(CloseChest());
            }
        }
    }

    private void SpawnRandomItem()
    {
        if (items.Length == 0)
        {
            Debug.LogWarning("Пусто");
            return;
        }

        int randomIndex = Random.Range(0, items.Length);
        GameObject itemToSpawn = items[randomIndex];

        Instantiate(itemToSpawn, spawnPoint.position, Quaternion.identity);
    }

    // Корутина для закриття сундука
    IEnumerator CloseChest()
    {
        yield return new WaitForSeconds(closeDelay);
        animator.SetTrigger("close");
    }
}
