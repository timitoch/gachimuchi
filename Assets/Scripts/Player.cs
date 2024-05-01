using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int key_count;
    public static Player Instance { get; private set; }
    [SerializeField] private float movingSpeed = 5f;
    private Rigidbody2D rb;

    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
       
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;
        Debug.Log(inputVector);
        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        
    }
    public bool IsRunning()
    {
            return isRunning;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }

    ////inventar
    //public Dictionary<string, int> inventory = new Dictionary<string, int>();

    //public void AddToInventory(string item)
    //{
    //    if (inventory.ContainsKey(item))
    //    {
    //        inventory[item]++;
    //    }
    //    else
    //    {
    //        inventory.Add(item, 1);
    //    }
    //}

    //public bool UseItem(string item)
    //{
    //    if (inventory.ContainsKey(item) && inventory[item] > 0)
    //    {
    //        inventory[item]--;
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    ////inventar
}