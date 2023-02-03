using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public static SpawnManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        SpawnManager.instance = this;
    }


    public GameObject[] Enemys = new GameObject[4];
    public GameObject ItemObject;
    public GameObject Yuggyo;
    public float Enemycooltime;
    float EnemyLastTime;
    public float Itemcooltime;
    float ItemLastTime;
    public float Trailcooltime;
    float TrailLastTime;
    public float Towercooltime;
    float TowerLastTime;
    float StartTime;

    public GameObject Trail;
    public GameObject[] Tower = new GameObject[2];
    public GameObject[] Tower2 = new GameObject[2];

    public GameObject[] DeliveryMap = new GameObject[2];

    float[] roads;
    int a, b, c, d, e;
    bool isSpawn;

    public int abs;

    bool isSpawnYuggyo;
    bool isSpawnFinish;

    public GameObject FinishLine;



    // Start is called before the first frame update
    void Start()
    {
        roads = new float[] { -7f, -4f, -0.65f, 2.7f, 5.9f };

        /*
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 10f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 20f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 30f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 40f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 50f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 60f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 70f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 80f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 90f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 100f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 110f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(13, -4f, 120f), Quaternion.identity);
        */
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 10f), Quaternion.identity);
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 20f), Quaternion.identity);
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 30f), Quaternion.identity);
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 40f), Quaternion.identity);
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 50f), Quaternion.identity);
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 60f), Quaternion.identity);
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 70f), Quaternion.identity); 
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 80f), Quaternion.identity);
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 90f), Quaternion.identity);
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 100f), Quaternion.identity);
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 110f), Quaternion.identity);
        Instantiate(Tower[Random.Range(0, 2)], new Vector3(13.5f, -3f, 120f), Quaternion.identity);
        
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 10f), Quaternion.identity);
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 20f), Quaternion.identity);
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 30f), Quaternion.identity);
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 40f), Quaternion.identity);
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 50f), Quaternion.identity);
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 60f), Quaternion.identity);
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 70f), Quaternion.identity);
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 80f), Quaternion.identity);
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 90f), Quaternion.identity);
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 100f), Quaternion.identity);
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 110f), Quaternion.identity);
        Instantiate(Tower2[Random.Range(0, 2)], new Vector3(-15.5f, -3f, 120f), Quaternion.identity);
        /*
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 10f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 20f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 30f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 40f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 50f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 60f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 70f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 80f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 90f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 100f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 110f), Quaternion.identity);
        Instantiate(Tower[Random.Range(2, 7)], new Vector3(18, -4f, 120f), Quaternion.identity);
        */



        isSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Enemy.i)
        {
            EnemyLastTime += Time.deltaTime;
            ItemLastTime += Time.deltaTime;
            StartTime += Time.deltaTime;
            TowerLastTime += Time.deltaTime;
        }
        if( Enemy.cb )
        {
            EnemyLastTime = -1;
            //Enemycooltime += Time.deltaTime;

            ItemLastTime = -1;
            //Itemcooltime += Time.deltaTime;
        }

        if( StartTime > 9)
        {

            if (EnemyLastTime >= Enemycooltime && !GameManager.Instance.eEnd && (ReadyScripts.Instance.NowDanGye == 0 || ReadyScripts.Instance.NowDanGye == 1))
            {
                EnemyLastTime = 0f;

                a = Random.Range(0, 7);
                b = Random.Range(0, 5);
                Instantiate(Enemys[a], new Vector3(roads[b], -3.5f, 65f), Quaternion.identity);

            }
            else if (EnemyLastTime >= Enemycooltime && !GameManager.Instance.eEnd && (ReadyScripts.Instance.NowDanGye != 0 && ReadyScripts.Instance.NowDanGye != 1))
            {
                EnemyLastTime = 0f;

                a = Random.Range(0, 7);

                b = Random.Range(0, 5);
                d = Random.Range(0, 5);

                if (b == d)
                {
                    Instantiate(Enemys[a], new Vector3(roads[b], -3.5f, 65f), Quaternion.identity);
                }
                else
                {
                    Instantiate(Enemys[Random.Range(0, 7)], new Vector3(roads[b], -3.5f, 65f), Quaternion.identity);
                    Instantiate(Enemys[Random.Range(0, 7)], new Vector3(roads[d], -3.5f, 65f), Quaternion.identity);
                }
            }

            if (ItemLastTime >= Itemcooltime && !GameManager.Instance.eEnd )
            {
                ItemLastTime = 0f;

                b = Random.Range(0, 5);
                Instantiate(ItemObject, new Vector3(roads[b], -1.9f, 65f), Quaternion.Euler(0, 180.0f, 0));
            }
        }

        

        if( MapMove.speed >= 60)
        {
            TrailLastTime += Time.deltaTime;
            if (MapMove.speed >= 130)
            {
                TrailLastTime += Time.deltaTime;
            }
        }

        if (TrailLastTime >= Trailcooltime)
        {
            TrailLastTime = 0f;
            Trailcooltime = Random.Range(0.2f, 0.8f);

            c = Random.Range(-13, -6);
            Instantiate(Trail, new Vector3(c, 0, 17f), Quaternion.Euler(0, -3.0f, 0));
            Instantiate(Trail, new Vector3(-c - 1.5f, 0, 67f), Quaternion.Euler(0, -3.0f, 0));
            c = Random.Range(-13, -6);
            Instantiate(Trail, new Vector3(c, 0, 27f), Quaternion.Euler(0, -3.0f, 0));
            Instantiate(Trail, new Vector3(-c - 1.5f, 0, 57f), Quaternion.Euler(0, -3.0f, 0));
            c = Random.Range(-13, -6);
            Instantiate(Trail, new Vector3(c, 0, 57f), Quaternion.Euler(0, -3.0f, 0));
            Instantiate(Trail, new Vector3(-c - 1.5f, 0, 27f), Quaternion.Euler(0, -3.0f, 0));
            c = Random.Range(-13, -6);
            Instantiate(Trail, new Vector3(c, 0, 67f), Quaternion.Euler(0, -3.0f, 0));
            Instantiate(Trail, new Vector3(-c - 1.5f, 0, 17f), Quaternion.Euler(0, -3.0f, 0));

            Instantiate(Trail, new Vector3(Random.Range(-9.65f, 8.35f), 0, 67f), Quaternion.Euler(0, -3.0f, 0));
            Instantiate(Trail, new Vector3(Random.Range(-9.65f, 8.35f), 0, 57f), Quaternion.Euler(0, -3.0f, 0));
            Instantiate(Trail, new Vector3(Random.Range(-9.65f, 8.35f), 0, 47f), Quaternion.Euler(0, -3.0f, 0));

        }
        
        if( MapMove.StreetCNT != 0 && MapMove.StreetCNT % 50 == 0 && !isSpawnYuggyo)
        {
            Instantiate(Yuggyo, new Vector3( 0.3f, 2.5f, 80f ), Quaternion.Euler( -90f, 0, 0));
            isSpawnYuggyo = true;
        }
        else if( MapMove.StreetCNT % 50 == 5 )
        {
            isSpawnYuggyo = false;
        }

        if ( MapMove.StreetCNT == GameManager.Instance.End[ReadyScripts.Instance.NowDanGye] - 3f && !isSpawnFinish)
        {
            Instantiate(FinishLine, new Vector3(-0.65f, 0f, 80f), Quaternion.Euler(0f, 180f, 0f));
            isSpawnFinish = true;
        }


        switch ( ReadyScripts.Instance.NowDanGye )
        {
            case 0:
                //芭痢 家券
                if (!isSpawn)
                {
                    if (MapMove.StreetCNT == 250f)
                    {
                        DeliveryMapSpawn();
                    }
                    if (MapMove.StreetCNT == 300f)
                    {
                        DeliveryMapSpawn();
                    }
                }
                //利 家券
                if (MapMove.speed > 150)
                    Enemycooltime = 0.5f;
                else if (MapMove.speed > 120)
                    Enemycooltime = 0.7f;
                else
                    Enemycooltime = 1.2f;

                Itemcooltime = 5f;
                break;
            case 1:
                if (!isSpawn)
                {
                    if (MapMove.StreetCNT == 300f)
                    {
                        DeliveryMapSpawn();
                    }
                    if (MapMove.StreetCNT == 400f)
                    {
                        DeliveryMapSpawn();
                    }
                }
                //利 家券
                if (MapMove.speed > 150)
                {
                    Enemycooltime = 0.5f;
                }
                else if (MapMove.speed > 120)
                {
                    Enemycooltime = 0.7f;
                }
                else
                {
                    Enemycooltime = 1.2f;
                }

                Itemcooltime = 6f;
                break;
            case 2:
                if (!isSpawn)
                {
                    if (MapMove.StreetCNT == 150f)
                    {
                        DeliveryMapSpawn();
                    }
                    if (MapMove.StreetCNT == 300f)
                    {
                        DeliveryMapSpawn();
                    }
                }
                //利 家券
                if (MapMove.speed > 150)
                {
                    Enemycooltime = 0.4f;
                }
                else if (MapMove.speed > 120)
                {
                    Enemycooltime = 0.6f;
                }
                else
                {
                    Enemycooltime = 1.2f;
                }

                Itemcooltime = 7f;
                break;
            case 3:
                if (!isSpawn)
                {
                    if (MapMove.StreetCNT == 100f)
                    {
                        DeliveryMapSpawn();
                    }
                    if (MapMove.StreetCNT == 220f)
                    {
                        DeliveryMapSpawn();
                    }
                }
                //利 家券
                if (MapMove.speed > 150)
                {
                    Enemycooltime = 0.4f;
                }
                else if (MapMove.speed > 120)
                {
                    Enemycooltime = 0.6f;
                }
                else
                {
                    Enemycooltime = 1.2f;
                }

                Itemcooltime = 7f;
                break;
            case 4:
                if (!isSpawn)
                {
                    if (MapMove.StreetCNT == 70f)
                    {
                        DeliveryMapSpawn();
                    }
                    if (MapMove.StreetCNT == 160f)
                    {
                        DeliveryMapSpawn();
                    }
                }
                //利 家券
                if (MapMove.speed > 150)
                {
                    Enemycooltime = 0.3f;
                }
                else if (MapMove.speed > 120)
                {
                    Enemycooltime = 0.5f;
                }
                else
                {
                    Enemycooltime = 1.2f;
                }

                Itemcooltime = 8f;
                break;
        }
    }


    void DeliveryMapSpawn()
    {
        abs = Random.Range(0, 2);
        if (abs == 0)
        {
            Instantiate(DeliveryMap[abs], new Vector3(-5.7f, -3f, 100f), Quaternion.Euler(-90f, 0, 0));
        }
        if (abs == 1)
        {
            Instantiate(DeliveryMap[abs], new Vector3(4.55f, -3f, 100f), Quaternion.Euler(-90f, 0, 0));
        }
        StartCoroutine(DeliveryCool());
        isSpawn = true;
    }

    IEnumerator DeliveryCool()
    {
        yield return new WaitForSeconds(1f);
        isSpawn = false;
    }

}
