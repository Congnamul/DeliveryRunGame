using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyScripts : MonoBehaviour
{
    public AudioClip BGMSound;
    public AudioClip PickAxe;
    AudioSource audioSource;

    private int[] SetDanGye = { -331, -160, 0, 160, 331 };
    float[] SetDatePositionX;
    float[] SetDatePositionY;

    private int NowArrow;
    //public static int NowDanGye = 0;
    public int NowDanGye = 0;
    private RectTransform rectTransform;
    public Image Arrow;
    private float Nowy;
    private bool GoUp;

    public Image image;
    public GameObject imageObj;

    public Text GoldTxt;
    public Text DateTxt;
    public Text DateWorkTxt;
    public Text NogadaWorkTxt;


    //******************************//
    //public static int Gold;
    //public static int Date;

    //public static int DateWork;
    
    public int Gold;
    public int Date;

    public int DateWork;
    public int NogadaWork;
    //******************************//


    public GameObject StartBtn;
    public GameObject ValuePhone;
    public Animator PhoneAnim;

    public RectTransform uiGroup;
    public RectTransform NogadaUI;
    public RectTransform StoreUI;
    public Text[] NogadaTxt = new Text[5];
    public GameObject NogadaCool;
    public GameObject NogadaStartBtn;
    int NogadaCNT;
    int NogadaDiamondCNT;
    int DiamondRan;
    float NogadaTime;

    public GameObject DateCheck;
    int cnt;

    bool isNogada;
    bool NogadaGold;

    float gadaTime;
    bool NogadaStart;
    bool NogadaReset;

    public Animator NogadaAnim;
    public RectTransform DobakUI;
    public InputField DobakInpurFeild;
    public GameObject DobakInpur;
    public GameObject goDobakBtn;
    public GameObject doBakBack;
    public Text BetingTxt;
    public Text NowGoldTxt;
    int BetingGold;
    public bool isDobakApp;
    bool DoDobakbtn;
    public Image[] BtnColor = new Image[3];
    public GameObject[] BtnEffect = new GameObject[6];
    public Text[] LastBox = new Text[3];
    public GameObject NoDobak;

    int ran;
    float besu;

    public int ItemBuyCnt;
    public int[] LastItemBuy = new int[3];
    public Text[] ItemTxt = new Text[3];
    public GameObject[] ItemBuyEffect = new GameObject[6];

    void OnApplicationQuit()
    {

    }

    //**************************************
    static ReadyScripts instance;

    public static ReadyScripts Instance
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
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
    }
    //**************************************


    // Start is called before the first frame update
    void Start()
    {

        SetDatePositionX = new float[] { 3f, 9.8f, 16.6f, 23.4f, 30.2f, 37f, 43.8f };
        SetDatePositionY = new float[] { -3f, -10.5f, -18f, -25.5f, -33f };

        NowDanGye = 0;
        rectTransform = GetComponent<RectTransform>();
        GoUp = true;
        Nowy = -70;

        isNogada = false;
        NogadaGold = false;
        NogadaCNT = 0;
        NogadaDiamondCNT = 0;
        NogadaTime = 10;
        gadaTime = 3;
        NogadaStart = false;
        DoDobakbtn = false;
        BetingGold = 0;
        besu = 0;

        this.audioSource = GetComponent<AudioSource>();
        audioSource.clip = BGMSound;
        audioSource.Play();

        if (SetDatePositionX[Date] == 3f)
        {
            cnt += 1;
        }
        DateCheck.transform.position = new Vector3(SetDatePositionX[(Date + 5) % 7], SetDatePositionY[cnt], 0);

        ItemBuyCnt = 0;

        ItemBuyEffect[0].SetActive(false);
        ItemBuyEffect[1].SetActive(false);
        ItemBuyEffect[2].SetActive(false);
        ItemBuyEffect[3].SetActive(false);
        ItemBuyEffect[4].SetActive(false);
        ItemBuyEffect[5].SetActive(false);


        LastItemBuy[0] = 0;
        LastItemBuy[1] = 0;
        LastItemBuy[2] = 0;

    }
    /*void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(16, 9, true);
    }*/


    // Update is called once per frame


    void Update()
    {
        Date = DateWork / 2;

        //DateTxt.text = (Date + 1) + "일 " + (DateWork % 2) + " / 2";

        DateTxt.text = "2022. 10. " + (Date + 1);
        DateWorkTxt.text = (DateWork % 2) + " / 2";
        NogadaWorkTxt.text = NogadaWork + " / 10";

        GoldTxt.text = Gold + " 원";
        ItemTxt[0].text = Gold + " 원";


        if ( ((Date - 2) == 0 || (Date - 2) == 7 || (Date - 2) == 14 || (Date - 2) == 22) && !isDobakApp)
        {
            NoDobak.SetActive(false);
            Debug.Log(Date + "/"+((Date - 2) % 7));
        }
        else
        {
            NoDobak.SetActive(true);
        }
        if( !((Date - 2) == 0 || (Date - 2) == 7 || (Date - 2) == 14 || (Date - 2) == 22) )
        {
            isDobakApp = false;
            NogadaReset = false;
        }

        if (((Date - 2) == 0 || (Date - 2) == 7 || (Date - 2) == 14 || (Date - 2) == 22) && !NogadaReset)
        {
            NogadaWork = 0;
            NogadaReset = true;
            
        }



        if (StartScript.reset)
        {
            Gold = 0;
            DateWork = 0;
            NogadaWork = 0;
            GameObject.Find("GameScript").GetComponent<DataManager>().JsonSave();
            StartScript.reset = false;
        }



        if ( NogadaStart )
        {
            gadaTime -= Time.deltaTime;
            if( gadaTime <= 0)
            {
                NogadaCool.SetActive(false);
                isNogada = true;
            }
            if( !isNogada )
            {
                NogadaTxt[4].text = ((int)gadaTime + 1) + "";
            }
        }


        if( isNogada && NogadaWork <= 10 )
        {
            if( !NogadaGold)
            {
                NogadaTime -= Time.deltaTime;
            }
 

            if( NogadaTime <= 0 && !NogadaGold )
            {
                Gold += ((NogadaCNT * 20) + (NogadaDiamondCNT * 50000));
                GameObject.Find("GameScript").GetComponent<DataManager>().JsonSave();
                
                isNogada = false;
                NogadaGold = true;

            }
            if ( Input.GetKeyDown(KeyCode.Space) && isNogada && !NogadaGold)
            {
                NogadaCNT += 1;
                NogadaAnim.SetTrigger("setSpace");

                audioSource.clip = PickAxe;
                audioSource.Play();

                DiamondRan = Random.Range(0, 1000);
                if( DiamondRan == 1 )
                {
                    NogadaDiamondCNT += 1;
                }

            }

        }



        NogadaTxt[0].text = "클릭 횟수 : " + NogadaCNT;
        NogadaTxt[1].text = "Gold : " + (NogadaCNT * 20f);
        NogadaTxt[2].text = "Jewel : " + NogadaDiamondCNT;
        NogadaTxt[3].text = "남은 시간 : " + (int)NogadaTime;

        if(DateWork >= 60)
        {
            if( Gold >= 3000000)
            {
                Debug.Log("성공");
                SceneManager.LoadScene("Complete 1");
            }
            else
            {
                Debug.Log("실패");

                SceneManager.LoadScene("Fail");
            }
        }


        switch (ItemBuyCnt)
        {
            case 0:
                ItemTxt[1].text = "";
                ItemTxt[2].text = "";
                break;
            case 1:
                ItemTxt[1].text = "목표 배달시간이 10분이 늘어납니다.";
                ItemTxt[2].text = "15000원";
                break;
            case 2:
                ItemTxt[1].text = "충돌을 한번 막아주는 쉴드를 생성합니다.";
                ItemTxt[2].text = "3000원";
                break;
            case 3:
                ItemTxt[1].text = "시작할 때 순간 부스터가 작동합니다.";
                ItemTxt[2].text = "7000원";

                break;
        }





    }

    public void OnCilck()
    {
        PhoneAnim.SetTrigger("setPhone");
        StartBtn.SetActive(false);
        Debug.Log("ASDASD");
    }
    public void OnCilckExit()
    {
        PhoneAnim.SetTrigger("ExitPhone");
        StartCoroutine(ExiteDel());
        Debug.Log("EXIT ");
    }

    IEnumerator ExiteDel()
    {
        yield return new WaitForSeconds(1.0f);
        StartBtn.SetActive(true);
    }

    public void OnCilckGameApp()
    {
        
        uiGroup.anchoredPosition = new Vector3(-14, -4, 0);
        StoreUI.anchoredPosition = new Vector3(0, -2500, 0);
        int Ran = Random.Range(0, 5);
        
        
        Debug.Log("GAMESTART");
    }    
    


    public void OnCilckExitGameApp()
    {
        NogadaStartBtn.SetActive(true);
        gadaTime = 3;
        isNogada = false;
        NogadaGold = false;
        NogadaStart = false;
        NogadaTime = 10;
        NogadaCNT = 0;
        NogadaDiamondCNT = 0;
        uiGroup.anchoredPosition = new Vector3(0, -1000, 0);
        NogadaUI.anchoredPosition = new Vector3(0, -1500, 0);
        StoreUI.anchoredPosition = new Vector3(0, -2500, 0);

        audioSource.clip = BGMSound;
        audioSource.Play();
    }

    public void OnCilckNogadaApp()
    {
        Debug.Log("노가다");
        NogadaUI.anchoredPosition = new Vector3(2, 0, 0);

    }



    public void GoLevel01()
    {
        imageObj.SetActive(true);
        StartCoroutine(StartFadeIN());
        NowDanGye = 0;
    }

    public void GoDobak()
    {
        PhoneAnim.SetTrigger("setDobak");
        StartCoroutine(DobakOn());
        isDobakApp = true;
    }

    IEnumerator DobakOn()
    {
        yield return new WaitForSeconds(1.2f);
        DobakUI.anchoredPosition = new Vector3(0, -12, 0);
        NowGoldTxt.text = "통장 잔고 : " + Gold;

    }




    IEnumerator StartFadeIN()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }

        SceneManager.LoadScene("OnGame");
    }

    public void NodaStart()
    {
        if( NogadaWork < 10)
        {
            NogadaStartBtn.SetActive(false);
            NogadaCool.SetActive(true);
            NogadaStart = true;
            NogadaWork += 1;
        }

    }



    public void setDobakGold()
    {
        BetingGold += int.Parse(DobakInpurFeild.text);
        if( (Gold - int.Parse(DobakInpurFeild.text)) >= 0)
        {
            Gold -= int.Parse(DobakInpurFeild.text);
            BetingTxt.text = "현재 배팅금액 : " + BetingGold;
            doBakBack.SetActive(false);
        }
        else if ((Gold - int.Parse(DobakInpurFeild.text)) < 0)
        {
            BetingGold -= int.Parse(DobakInpurFeild.text);
            BetingTxt.text = "현재 배팅금액 : " + BetingGold + " < 금액이 부족합니다. >";
        }

        DobakInpur.SetActive(false);
        goDobakBtn.SetActive(false);
        NowGoldTxt.text = "통장 잔고 : " + Gold;

    }

    public void OnCilckExitDobak()
    {
        DobakInpurFeild.text = "";
        PhoneAnim.SetTrigger("ExitDobak");
        DobakUI.anchoredPosition = new Vector3(0, -2000, 0);
        DoDobakbtn = false;
        DobakInpur.SetActive(true);
        doBakBack.SetActive(true);
        goDobakBtn.SetActive(true);

        BtnColor[0].color = Color.white;
        BtnColor[1].color = Color.white;
        BtnColor[2].color = Color.white;
        BtnEffect[0].SetActive(true);
        BtnEffect[2].SetActive(true);
        BtnEffect[4].SetActive(true);

    }

    public void DoDobak()
    {
        if( !DoDobakbtn)
        {
            ran = Random.Range(0, 5);
            Debug.Log(ran);

            if (ran == 0)
            {
                besu = -1;
            }
            else if (ran == 1)
            {
                besu = 0f;
            }
            else if (ran == 2)
            {
                besu = 1;
            }
            else if (ran == 3)
            {
                besu = 2;
            }
            else
            {
                besu = 3;
            }
            BetingGold = (int)(BetingGold * besu);
            Gold += BetingGold;
            BetingGold = 0;
            BetingTxt.text = "현재 배팅금액 : " + BetingGold;
            DobakInpurFeild.text = "";
            doBakBack.SetActive(true);
        }




    }




    public void btnClick01()
    {
        if( !DoDobakbtn)
        {
            StartCoroutine(BoxOpen01());
            
        }
        LastBox[0].text = besu + "배!";

        LastBox[1].text = Random.Range(-1,4) + "배!";
        LastBox[2].text = Random.Range(-1, 4) + "배!";
    }
    IEnumerator BoxOpen01()
    {
        DoDobakbtn = true;
        BtnColor[0].color = Color.red;

        yield return new WaitForSeconds(1f);

        BtnEffect[0].SetActive(false);
        BtnEffect[1].SetActive(true);

        yield return new WaitForSeconds(0.8f);

        BtnEffect[1].SetActive(false);

        NowGoldTxt.text = "통장 잔고 : " + Gold;
        yield return new WaitForSeconds(0.5f);
        BtnEffect[2].SetActive(false);
        BtnEffect[3].SetActive(true);
        BtnEffect[4].SetActive(false);
        BtnEffect[5].SetActive(true);
        yield return new WaitForSeconds(0.8f);
        BtnEffect[3].SetActive(false);
        BtnEffect[5].SetActive(false);

    }


    public void btnClick02()
    {
        if (!DoDobakbtn)
        {
            StartCoroutine(BoxOpen02());
        }
        LastBox[1].text = besu + "배!";

        LastBox[0].text = Random.Range(-1, 4) + "배!";
        LastBox[2].text = Random.Range(-1, 4) + "배!";
    }
    IEnumerator BoxOpen02()
    {
        DoDobakbtn = true;
        BtnColor[1].color = Color.red;

        yield return new WaitForSeconds(1f);

        BtnEffect[2].SetActive(false);
        BtnEffect[3].SetActive(true);

        yield return new WaitForSeconds(0.8f);

        BtnEffect[3].SetActive(false);

        NowGoldTxt.text = "통장 잔고 : " + Gold;
        yield return new WaitForSeconds(0.5f);
        BtnEffect[0].SetActive(false);
        BtnEffect[1].SetActive(true);
        BtnEffect[4].SetActive(false);
        BtnEffect[5].SetActive(true);
        yield return new WaitForSeconds(0.8f);
        BtnEffect[1].SetActive(false);
        BtnEffect[5].SetActive(false);

    }

    public void btnClick03()
    {
        if (!DoDobakbtn)
        {
            StartCoroutine(BoxOpen03());
        }
        LastBox[2].text = besu + "배!";

        LastBox[1].text = Random.Range(-1, 4) + "배!";
        LastBox[0].text = Random.Range(-1, 4) + "배!";
    }
    IEnumerator BoxOpen03()
    {
        DoDobakbtn = true;
        BtnColor[2].color = Color.red;

        yield return new WaitForSeconds(1f);

        BtnEffect[4].SetActive(false);
        BtnEffect[5].SetActive(true);

        yield return new WaitForSeconds(0.8f);

        BtnEffect[5].SetActive(false);

        NowGoldTxt.text = "통장 잔고 : " + Gold;
        yield return new WaitForSeconds(0.5f);
        BtnEffect[2].SetActive(false);
        BtnEffect[3].SetActive(true);
        BtnEffect[0].SetActive(false);
        BtnEffect[1].SetActive(true);
        yield return new WaitForSeconds(0.8f);
        BtnEffect[3].SetActive(false);
        BtnEffect[1].SetActive(false);

    }



    public void OnCilckStoreApp()
    {
        StoreUI.anchoredPosition = new Vector3(2, -10, 0);
    }




    public void StoreItemBtn01()
    {
        ItemBuyCnt = 1;
        ItemBuyEffect[0].SetActive(true);
        ItemBuyEffect[1].SetActive(false);
        ItemBuyEffect[2].SetActive(false);
    }
    public void StoreItemBtn02()
    {
        ItemBuyCnt = 2;
        ItemBuyEffect[1].SetActive(true);
        ItemBuyEffect[0].SetActive(false);
        ItemBuyEffect[2].SetActive(false);
    }
    public void StoreItemBtn03()
    {
        ItemBuyCnt = 3;
        ItemBuyEffect[2].SetActive(true);
        ItemBuyEffect[0].SetActive(false);
        ItemBuyEffect[1].SetActive(false);
    }


    public void StoreItemBUY()
    {
        switch (ItemBuyCnt)
        {
            case 0:
                break;
            case 1:
                if( LastItemBuy[0] != 1)
                {
                    ItemBuyEffect[3].SetActive(true);
                    Gold -= 15000;
                    LastItemBuy[0] = 1;

                }
                break;
            case 2:
                if( LastItemBuy[1] != 1)
                {
                    ItemBuyEffect[4].SetActive(true);
                    Gold -= 3000;
                    LastItemBuy[1] = 1;

                }
                break;
            case 3:
                if( LastItemBuy[2] != 1)
                {
                    ItemBuyEffect[5].SetActive(true);
                    Gold -= 7000;
                    LastItemBuy[2] = 1;

                }
                break;
        }


    }











}
