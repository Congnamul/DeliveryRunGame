using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    public static PlayerMove Instance
    {
        get
        {
            return instance;
        }
    }

    Rigidbody rigid;
    Collider PlayerColl;

    Vector3 Myvec;
    Vector3 vector;
    public MapMove Map;
    //public Enemy Enemy;

    public GameObject MagicRing;
    public GameObject ShadowPlayer;
    public GameObject KalParticle;
    public GameObject BarrierObj;

    float SpeedFloat;


    public float moveSpeed;

    private bool MoveLeft;
    private bool MoveRight;
    bool test;
    bool isFinish;
    bool isBreak;
    bool isShoot;
    bool StartBoostON;

    float[] roads;
    int currentPos;
    int targetPos;

    public bool SSHIIBAL;
    public GameObject BreakEffect;
    public GameObject ItemEffect;
    public GameObject DeliveryBoxs;
    bool isSpace;

    AudioSource audioSource;
    public AudioClip Boost;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        PlayerMove.instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Myvec.z = transform.position.z;
        rigid = GetComponent<Rigidbody>();
        PlayerColl = GetComponent<Collider>();
        roads = new float[] { -7f, -4f, -0.65f, 2.7f, 5.9f };
        currentPos = 2;
        targetPos = 2;
        MagicRing.SetActive(false);

        isShoot = false;
        StartBoostON = false;

        if (ReadyScripts.Instance.LastItemBuy[1] == 1)
        {
            GameManager.Instance.OnBarrier = true;
            StartCoroutine(useItem());
        }
        if (ReadyScripts.Instance.LastItemBuy[2] == 1)
        {
            StartBoostON = true;
        }

        audioSource = GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
        if( SSHIIBAL)
        {
            Physics.IgnoreLayerCollision(6, 7, true);
        }
        else
        {
            Physics.IgnoreLayerCollision(6, 7, false);
        }

        if( !isBreak && Enemy.i)
        {
            Instantiate(BreakEffect, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + 2), Quaternion.identity);
            isBreak = true;
        }else if( !Enemy.i)
        {
            isBreak = false;
        }


        if (MoveLeft || MoveRight)
        {
            Vector3 newPos = transform.position;
            float delta = Math.Min(Math.Abs(roads[targetPos] - newPos.x), moveSpeed * Time.deltaTime * 150);
            newPos.x = (MoveLeft) ? (newPos.x - delta) : (newPos.x + delta);
            transform.position = newPos;
            if (roads[targetPos] == transform.position.x)
            {
                MoveLeft = MoveRight = false;
                currentPos = targetPos;
            }
        }
        // input check, move car (left, right, jump)
        if (!MoveLeft && !MoveRight && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && !isFinish)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && currentPos != 0)
            {
                MoveLeft = true;
                targetPos = currentPos - 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && currentPos != 4)
            {
                MoveRight = true;
                targetPos = currentPos + 1;
            }
            if (MoveLeft || MoveRight) StartCoroutine(RotateLR());

        }

        SpeedFloat = ((MapMove.speed - 30) / 10) - 5.5f;

        if(SpeedFloat <= -5.5f)
        {
            SpeedFloat = -5.5f;
        }

        

        vector = transform.position;

        if ( Enemy.i && !GameManager.Instance.OnBarrier )
        {
            vector.z = Mathf.Lerp(transform.position.z, -5.3f, Time.deltaTime);
            MagicRing.SetActive(false);
        }
        else
        {
            if (MapMove.speed > 20 && MapMove.speed < 300)
            {
                vector.z = Mathf.Lerp(transform.position.z, SpeedFloat, Time.deltaTime);
                MagicRing.SetActive(true);
            }
        }
        transform.position = vector;

        if( vector.z < -5.5f)
        {
            vector.z = -5.5f;
        }


        if (GameManager.Instance.OnShadow || SSHIIBAL)
        {
            ShadowPlayer.SetActive(true);
        }
        else
        {
            ShadowPlayer.SetActive(false);
        }



        if (Input.GetKey(KeyCode.Space) && GameManager.Instance.Startbool)
        {
            if(MapMove.speed >= 30) MapMove.speed -= 0.1f;
        }


        if( StartBoostON)
        {
            Debug.Log("BOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            StartCoroutine(StartBoost());
            StartBoostON = false;
        }
    }



    IEnumerator RotateLR()
    {
        if (MoveLeft)
        {
            for (int i = 0; i < 5; ++i) // rotate
            {
                transform.Rotate(new Vector3(0, -1, 0) * 5);
                yield return new WaitForSeconds(0.01f);
            }
            for (int i = 0; i < 5; ++i) // rotate
            {
                transform.Rotate(new Vector3(0, 1, 0) * 5);
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            for (int i = 0; i < 5; ++i) // rotate
            {
                transform.Rotate(new Vector3(0, 1, 0) * 5);
                yield return new WaitForSeconds(0.01f);
            }
            for (int i = 0; i < 5; ++i) // rotate
            {
                transform.Rotate(new Vector3(0, -1, 0) * 5);
                yield return new WaitForSeconds(0.01f);
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "EnemyBack")
        {
            if(!Enemy.i)
            {
                audioSource.clip = Boost;
                audioSource.Play();

                MapMove.speed += 15;
                StartCoroutine(KalShadow());
                Debug.Log("Kal");
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(!GameManager.Instance.isItemOn)
        {
            if (other.tag == "ItemBox")
            {
                StartCoroutine(useItem());
                Destroy(other.gameObject);
            }
        }

        if (other.tag == "DeliveryMap")
        {
            isShoot = false;
        }



    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "DeliveryMap")
        {
            if (Input.GetKey(KeyCode.Space))
            {                
                if( !isShoot )
                {
                    GameManager.Instance.MissionDelivery += 1;

                    DeliveryBox.goDelivery = SpawnManager.instance.abs;

                    Instantiate(DeliveryBoxs, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + 1f), Quaternion.identity);
                    DeliveryPosition.isEffect = true;

                    Debug.Log("배달 성공" + GameManager.Instance.MissionDelivery);
                    MapMove.speed = 60;
                    isShoot = true;


                }
            }
        }
    }


    IEnumerator useItem()
    {
        Instantiate(ItemEffect, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + 1f), Quaternion.identity);
        
        if ( !GameManager.Instance.OnBarrier || GameManager.Instance.OnShadow )
        {
            GameManager.Instance.isEat = true;
            yield return new WaitForSeconds(0.1f);
            if ( GameManager.Instance.OnShadow )
            {
                SSHIIBAL = true;
                StartCoroutine(OFFShadow());
            }

        }
        if ( GameManager.Instance.OnBarrier )
        {
            BarrierObj.SetActive(true);
        }
        
    }

    IEnumerator OFFShadow()
    {        
        yield return new WaitForSeconds(3f);
        SSHIIBAL = false;
        GameManager.Instance.OnShadow = false;
    }

    IEnumerator KalShadow()
    {
        KalParticle.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        KalParticle.SetActive(false);
    }

    IEnumerator StartBoost()
    {
        MapMove.speed += 100;
        yield return new WaitForSeconds(5f);
        if (MapMove.speed >= 100)
        {
            MapMove.speed = 60;
        }

    }


}
