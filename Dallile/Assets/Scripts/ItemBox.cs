using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    float rotSpeed = 100f;
    public int a;

    int b;

    // Update is called once per frame
    void Update()
    {

        Vector3 pos;
        pos = this.gameObject.transform.position;

        if( a == 1)
        {
            Enemy.speed = MapMove.speed * 0.1f;
            transform.position = transform.position + new Vector3(0, 0, -Enemy.speed) * Time.deltaTime;
            transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
        }

        if (a == 2)
        {
            transform.position = transform.position + new Vector3(0, 0, -MapMove.speed * 1.5f) * Time.deltaTime;
        }
        
        if (a == 3)
        {
            transform.position = transform.position + new Vector3(0, 0, -MapMove.speed) * Time.deltaTime;

            if(transform.position.z <= -15)
            {
                b = Random.Range(0, 2);

                Instantiate(SpawnManager.Instance.Tower[b], new Vector3(transform.position.x, -4f, 60f), Quaternion.identity);
                
                Debug.Log(SpawnManager.Instance.Tower[b].transform.eulerAngles); 
                Destroy(gameObject);
            }

        }
        if (a == 4)
        {
            transform.position = transform.position + new Vector3(0, 0, -MapMove.speed) * Time.deltaTime;

            if (transform.position.z <= -15)
            {
                b = Random.Range(0, 2);

                Instantiate(SpawnManager.Instance.Tower2[b], new Vector3(transform.position.x, -3f, 60f), Quaternion.identity); 

                Debug.Log(SpawnManager.Instance.Tower[b].transform.eulerAngles);
                Destroy(gameObject);
            }

        }
        if (a == 5)
        {
            transform.position = transform.position + new Vector3(0, 0, -MapMove.speed) * Time.deltaTime;

        }

        if (a == 10)
        {
            transform.Rotate(new Vector3(0, -rotSpeed * 0.5f * Time.deltaTime, 0));

        }

        if (pos.z <= -15)
        {
            Destroy(gameObject);
        }

        


    }
}
