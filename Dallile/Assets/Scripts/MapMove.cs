using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{

    public static float speed;
    float leftTime = 0.1f;
    public static int StreetCNT;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        StreetCNT = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        pos = this.gameObject.transform.position;

        transform.position = transform.position + new Vector3(0, 0, -speed) * Time.deltaTime;

        if (pos.z <= -40)
        {
            transform.Translate(new Vector3(0, 0, 40f), Space.World);
            StreetCNT += 1;
        }

        if(leftTime > 0)
        {
            leftTime -= Time.deltaTime;
        }
        else
        {

            leftTime = 0.1f;

            if (speed > 260)
            {
                speed -= 5f;
            }
            if (speed < 100)
            {
                speed++;
            }
            else if(speed > 120.2f)
            {
                speed -= 1f;
            }

        }
    }

}
