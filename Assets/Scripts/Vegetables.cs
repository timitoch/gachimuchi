using UnityEngine;
using System.Collections;

public class Vegetables : MonoBehaviour
{
    public GameObject plant;
    public float growthDuration = 20f;
    public float wateringDuration = 1f;
    public Animator animator;
    public Player player;
    public float range = 1f;

    private bool isGrowing = false;
    private bool canWater = true;
    private bool canHarvest = false;
    private int currentState = 0;
    private float growthTimer = 0f;
    private float wateringTimer = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(GrowPlant());
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        bool isNearPlant = distance <= range;

        if (isNearPlant)
        {
            if (canWater && Input.GetKeyDown(KeyCode.E))
            {
                Water();
            }
            else if (canHarvest && Input.GetKeyDown(KeyCode.E))
            {
                Harvest();
            }
        }
    }

    IEnumerator GrowPlant()
    {
        while (true)
        {
            yield return new WaitForSeconds(growthDuration);
            Water();
        }
    }

    private void Water()
    {
        if (Time.time - wateringTimer > wateringDuration)
        {
            wateringTimer = Time.time;
            isGrowing = true;

            if (currentState == 0)
            {
                animator.SetTrigger("state1");
                currentState = 1;
            }
            else if (currentState == 1)
            {
                animator.SetTrigger("state2");
                currentState = 2;
            }
            else if (currentState == 2)
            {
                animator.SetTrigger("state3");
                currentState = 3;
                canHarvest = true;
            }
            else if (currentState == 3)
            {
                Harvest();
            }
        }
    }

    private void Harvest()
    {
        if (canHarvest)
        {
            canHarvest = false;
            currentState = 0;
            Instantiate(plant, transform.position, Quaternion.identity);
            //animator.SetTrigger("state0");
            Destroy(gameObject );
            isGrowing = false;
        }
    }
}
