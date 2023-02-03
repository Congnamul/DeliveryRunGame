using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBox : MonoBehaviour
{

    public static int goDelivery;
    Rigidbody rigid;
    bool isShoot;

    // Start is called before the first frame update
    void Start()
    {
        isShoot = false;
        rigid = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 100f * Time.deltaTime, 0));

        if ( !isShoot && goDelivery == 0)
        {
            Debug.Log("LEFT");
            rigid.AddForce(transform.up * 400f, ForceMode.Force);
            rigid.AddForce(transform.right * -1000f, ForceMode.Force);
            isShoot = true;
        }
        if(!isShoot && goDelivery == 1)
        {
            Debug.Log("RIGHT");
            rigid.AddForce(transform.up * 400f, ForceMode.Force);
            rigid.AddForce(transform.right * 1000f, ForceMode.Force);
            isShoot = true;
        }
    }
}
