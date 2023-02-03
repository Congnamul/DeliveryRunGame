using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MapMove street;
    public Text spd;
    //public Text Timer;
    public Text ToTimer;
    public Text StartText;
    public Text LevelTxt;
    public Image LevelImage;
    float StartInt;
    //public Transform Stick;
    public Slider MiniPlayer;

    public int[] itemNum = new int[3];
    public static int a;

    public bool OnShadow;
    public bool OnBarrier;
    public bool OnBumper;
    public bool booster;
    public bool isItemOn;
    public bool isEat;
    bool isEatPre = false;

    private float Time_Sec;
    private float Time_Min;

    private int EndTi_Min;
    private int EndTi_Sec;

    public int stage ;
    public int[] End = new int[5];
    public int[] TimeEnd = new int[5];
    public static int star;
    private int EarnGold;
    private float times;
    public GameObject[] EndImage = new GameObject[2];
    public Text[] EndText = new Text[6];
    public GameObject[] Stars = new GameObject[5];
    public GameObject[] XStars = new GameObject[5];

    float sec, min;
    public int cnt;
    public bool eEnd;
    public bool Startbool;
    bool GoldBool;
    bool DateCheck;
    

    public GameObject BreakEffect;
    public RectTransform[] DeliveryFlag = new RectTransform[2];

    public Image SkillTxT;
    public Sprite[] SkillSprites= new Sprite[3];
    public GameObject Loading;

    //public List<string> testDataA = new List<string>();
    //public List<int> testDataB = new List<int>();

    AudioSource audioSource;

    //***********************************
    public int playerGold = 0;
    public int playerPower;
    //************************************

    public int breakCnt;

    static GameManager instance;

    public int MissionDelivery;
    Color color;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
              

    }

    void Start()
    {

        stage = ReadyScripts.Instance.NowDanGye;
        a = -1;
        isEat = false;
        OnBumper = false;
        OnShadow = false;
        booster = false;
        isItemOn = false;
        isEatPre = false;
        eEnd = false;
        End = new int[] { 450, 500, 400, 350, 250 };
        TimeEnd = new int[] { 210, 210, 180, 150, 90 }; 

        if ( ReadyScripts.Instance.LastItemBuy[0] == 1)
        {
            TimeEnd[stage] += 60;
            
        }


        StartInt = 10;
        Time_Sec = TimeEnd[stage] % 60;
        Time_Min = TimeEnd[stage] / 60;
        Startbool = false;

        sec = TimeEnd[stage];
        min = sec / 6;
        ToTimer.text = (int)min + " : " + (int)(sec * 10 % 60);

        GoldBool = false;
        DateCheck = false;

        MissionDelivery = 0;

        Loading.SetActive(false);

        switch (stage)
        {
            case 0:
                //LevelTxt.color = new Color(133, 255, 68);
                //LevelImage.color = new Color(133, 255, 68);
                LevelTxt.color = Color.Lerp(Color.red, Color.green, 0.9f);
                LevelImage.color = Color.Lerp(Color.red, Color.green, 0.9f);

                DeliveryFlag[0].anchoredPosition = new Vector3(-580, 420, 0) ;
                DeliveryFlag[1].anchoredPosition = new Vector3(-525, 420, 0);
                break;
            case 1:
                LevelTxt.color = Color.Lerp(Color.yellow, Color.green, 0.5f);
                LevelImage.color = Color.Lerp(Color.yellow, Color.green, 0.5f);
                DeliveryFlag[0].anchoredPosition = new Vector3(-561, 420, 0);
                DeliveryFlag[1].anchoredPosition = new Vector3(-471, 420, 0);
                break;
            case 2:
                LevelTxt.color = Color.yellow;
                LevelImage.color = Color.yellow;
                DeliveryFlag[0].anchoredPosition = new Vector3(-662, 420, 0);
                DeliveryFlag[1].anchoredPosition = new Vector3(-495, 420, 0);
                break;
            case 3:
                LevelTxt.color = Color.Lerp(Color.red, Color.yellow, 0.5f);
                LevelImage.color = Color.Lerp(Color.red, Color.yellow, 0.5f);
                DeliveryFlag[0].anchoredPosition = new Vector3(-702, 420, 0);
                DeliveryFlag[1].anchoredPosition = new Vector3(-550, 420, 0);
                break;
            case 4:
                LevelTxt.color = Color.red;
                LevelImage.color = Color.red;
                DeliveryFlag[0].anchoredPosition = new Vector3(-705, 420, 0);
                DeliveryFlag[1].anchoredPosition = new Vector3(-544, 420, 0);
                break;
        }
    }


    void Update()
    {        

        spd.text = "" + (int)MapMove.speed;
        //Stick.eulerAngles = new Vector3(0, 0, -MapMove.speed);

        LevelTxt.text = "Lv. " + (int)(stage+1);
        cnt = MapMove.StreetCNT;

        if (MapMove.StreetCNT >= End[stage])
        {
            MapMove.speed = 0;
            eEnd = true;
        }

        MiniPlayer.value = (float)MapMove.StreetCNT / (float)End[stage];

        if (isEatPre)
        {
            isEatPre = false;
            isItemOn = true;
            a = Random.Range(0, 3);
            StartCoroutine(OnTextChange());
            if (a == 0)
            {
                Debug.Log("BOOOOOOOST");
                StartCoroutine(Boost());
            }
            if (a == 1)
            {
                Debug.Log("Shadow");
                StartCoroutine(OnshadowChange());
                OnShadow = true;
            }
            if (a == 2)
            {
                OnBarrier = true;

                Debug.Log("Barrier");

            }
        }

        if ( isEat )
        {
            isEat = false;
            isEatPre = true;
        }


        
        
        //Timer.text = "목표 시간 " + ((TimeEnd[stage]*10)/60) + " 분";

        if( !eEnd && Startbool)
        {
            sec -= Time.deltaTime;
            min = sec / 6;
            if( sec > 0)
            {
                ToTimer.text = (int)min + " : " + (int)(sec * 10 % 60);
            }else if( sec < 0)
            {
                ToTimer.text = (int)min + " : " + (int)(sec * -10 % 60);
            }
 
        }

        if( !Startbool)
        {
            if( MapMove.speed >= 100)
            {
                Startbool = true;
            }
        }
        
        StartInt -= Time.deltaTime;




        if (StartInt < 0)
        {
            StartText.enabled = false;
        }
        if (StartInt < 9 && StartInt > 0)
        {
            StartText.enabled = true;
            StartText.text = "Ready?";
        }
        if (StartInt < 4)
        {
            StartText.text = "" + (int)StartInt;
        }

        if( eEnd )
        {
            int i = (int)sec;

            EndImage[0].SetActive(true);
            EndImage[1].SetActive(true);

            if ( !DateCheck)
            {
                ReadyScripts.Instance.DateWork += 1;
                DateCheck = true;
            }


            if (i >= 30)  
            {
                star = 5;
                Debug.Log("5별");
            }
            else if (i >= 0)
            {
                star = 4;
                Debug.Log("4별"); 
            }
            else if (i >= -30)
            {
                star = 3;
                Debug.Log("3별");
            }
            else if (i >= -60)
            {
                star = 2;
                Debug.Log("2별");
            }
            else if (i >= -90)
            {
                Debug.Log("1별");
                star = 1;
            }
            else
            {
                Debug.Log("1별");
                star = 1;
                
            }

        }

        if (eEnd && !GoldBool)
        {
            switch (stage)
            {
                case 0:
                    EarnGold = 4000;
                    break;
                case 1:
                    EarnGold = 5000;
                    break;
                case 2:
                    EarnGold = 6000;
                    break;
                case 3:
                    EarnGold = 7000;
                    break;
                case 4:
                    EarnGold = 10000;
                    break;
                default:
                    break;
            }



            switch (star)
            {
                case 1:
                    times = -2;
                    EndText[5].text = "배달을 걸어서 오나요? 다시는 주문 안할거에요.";

                    break;
                case 2:
                    times = -1;
                    EndText[5].text = "배달도 느리고 음식도 음식이 누락됬어요.";

                    break;
                case 3:
                    times = 1;
                    EndText[5].text = "배달도 느리고 음식이 흔들렸어요.";

                    break;
                case 4:
                    times = 1.5f;
                    EndText[5].text = "배달은 빨랐는데 음식이 식었어요.";

                    break;
                case 5:
                    times = 2;
                    EndText[5].text = "배달도 빠르고 음식도 맛있어요!";

                    break;
                default:
                    break;
            }

            StartCoroutine(OnStarSet());

            ReadyScripts.Instance.Gold += (int)((EarnGold + MissionDelivery * EarnGold) * times);


            GoldBool = true;
            GameObject.Find("DataManager").GetComponent<DataManager>().JsonSave();


            EndText[0].text = (stage + 1) + "단계";
            EndText[1].text = "2022 10 " + (ReadyScripts.Instance.Date + 1) ;
            //if()
            EndText[2].text = breakCnt + "회"; //충돌횟수로 수정 부탁 ** 
            EndText[3].text = (int)((EarnGold + MissionDelivery * EarnGold) * times) + "";
            EndText[4].text = ReadyScripts.Instance.Gold + "";



            //DataManager.JsonSave()
        }





    }

    void Timecal(int a)
    {

        a *= 10;
        


    }

    IEnumerator OnshadowChange()
    {
        isEatPre = false;
        PlayerMove.instance.ShadowPlayer.SetActive(true);
        yield return new WaitForSeconds(3f);
        PlayerMove.instance.ShadowPlayer.SetActive(false);
        isItemOn = false;
        OnShadow = false;
    }

    IEnumerator Boost()
    {
        MapMove.speed += 100;
        yield return new WaitForSeconds(5f);
        if( MapMove.speed >= 100)
        {
            MapMove.speed = 100;
        }
        isItemOn = false;
        OnShadow = false;
    }

    IEnumerator OnTextChange()
    {
        SkillTxT.sprite = SkillSprites[a];
        SkillTxT.color = new Color(255, 255, 255, 255f);
        

        float fadeCount = 1.1f;

        while (fadeCount > 0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            SkillTxT.color = new Color(255, 255, 255, fadeCount);
        }


    }


    IEnumerator OnStarSet()
    {

        for(int i = 0 ; i < star; i += 1)
        {
            yield return new WaitForSeconds(0.5f);
            Stars[i].SetActive(true);
        }

    }


    public void OnClickReset()
    {
        Loading.SetActive(true);
        StartCoroutine(LoadingEnd());
    }

    IEnumerator LoadingEnd()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Start");
    }



}
