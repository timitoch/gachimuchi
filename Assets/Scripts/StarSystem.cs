using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : MonoBehaviour
{
    public static int Object = 2;
    public GameObject Star, Fruit;


    void Update()
    {
        Debug.Log(Object);
        switch (Object)
        {
            case 0:
                Star.SetActive(true);
                Fruit.SetActive(true);
                break;
            
        }

    }
}

