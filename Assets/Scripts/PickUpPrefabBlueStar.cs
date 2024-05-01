//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PickUpPrefabBlueStar : MonoBehaviour
//{
//    public Player player;
//    public string itemName = "Plant";
//    private bool isPickedUp = false;

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player") && !isPickedUp)
//        {
//            StartCoroutine(PickupPlant());
//        }
//    }

//    IEnumerator PickupPlant()
//    {
//        isPickedUp = true;
//        player.AddToInventory(itemName);
//        yield return new WaitForSeconds(1);
//        Destroy(gameObject);
//    }
//}
