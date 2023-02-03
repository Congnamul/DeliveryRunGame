using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed;
    public MapMove Map;

    public Rigidbody rigid;
    public Collider col;
    
    public GameObject SpeedEffect;

    Vector3 pos;

    int CrashCount = 0;
    bool isCrash;
    public static bool i;
    public static bool s;
    bool k;
    public static bool cb;




    // Start is called before the first frame update
    void Start()
    {
        CrashCount = 0;
        i = false;
        isCrash = true;
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        if (!k)
        {
            if( MapMove.speed > 10)
            {
                speed = MapMove.speed * 0.15f;
            }
            else if( MapMove.speed <= 10)
            {
                speed = -3;
            }else if (MapMove.speed <= 5)
            {
                speed = -20;
            }
            
            transform.position = transform.position + new Vector3(0, 0, -speed) * Time.deltaTime;
            //pos = pos + new Vector3(0, 0, -speed) * Time.deltaTime;
        }
        if (k)
        {
            speed = 8;
            transform.position = transform.position + new Vector3(0, 0, speed) * Time.deltaTime;

            //transform.position = transform.position + new Vector3(0, 0, 5f) * Time.deltaTime;
            //pos = pos + new Vector3(0, 0, 5f) * Time.deltaTime;

            MapMove.speed = 10;
        }

        if (pos.z <= -15)
        {
            Destroy(gameObject);
        }
        if( MapMove.speed > 40)
        {
            SpeedEffect.SetActive(true);
        }
        else
        {
            SpeedEffect.SetActive(false);
        }


    }




    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && !PlayerMove.instance.SSHIIBAL)
        {
            col.isTrigger = true;
            isCrash = false;
            Debug.Log("Doom");
            CrashCount += 1;
            GameManager.Instance.breakCnt += 1;
            StartCoroutine(OnCrash());
        }

    }





    IEnumerator OnCrash()
    {
        cb = true;
        yield return new WaitForSeconds(0.01f);
        cb = false;

        if (CrashCount == 2 || GameManager.Instance.OnBarrier )
        {   
            if( GameManager.Instance.OnBarrier )
            {
                GameManager.Instance.isItemOn = false;
                GameObject.Find("Barrier").SetActive(false);
                GameManager.Instance.OnBarrier = false;
                i = false;
                k = false;
            }
            Destroy(gameObject);
        }
        else if (CrashCount == 1 && !GameManager.Instance.OnBarrier  )
        {
            i = true;
            k = true;
            yield return new WaitForSeconds(1f);
            i = false;
            k = false;
        }
        yield return new WaitForSeconds(1f);
        col.isTrigger = false;
        isCrash = true;
    }





}
