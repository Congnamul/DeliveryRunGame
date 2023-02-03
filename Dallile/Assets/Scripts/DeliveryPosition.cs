using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPosition : MonoBehaviour
{
    public GameObject DeliveryEffect;

    public static bool isEffect;



    // Start is called before the first frame update
    void Start()
    {
        isEffect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( isEffect )
        {
            SpawnEffect();
            isEffect = false;
        }
    }

    public void SpawnEffect()
    {
        Instantiate(DeliveryEffect, transform.position, Quaternion.Euler(-90f, 0, 0));
        Destroy(gameObject);
    }



}
