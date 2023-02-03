using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    public Image image;
    public GameObject imageObj;
    
    public static bool isStart;
    
    public int a;
    public static bool isStartCount;

    public static bool reset;
        
    // Start is called before the first frame update
    void Start()
    {
        if ( a == 1 )
        {
            imageObj.SetActive(true);
            StartCoroutine(StartFadeOUT());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoStartButton()
    {

        Debug.Log("Start");

        if (a == 0 && !isStart )
        {
            StartCoroutine(StartFadeINWebtoon());
        }
        if (a == 0 && isStart)
        {
            StartCoroutine(StartFadeIN());
        }
    }

    public void GoResetButton()
    {
        Debug.Log("Reset");

        reset = true;
        StartCoroutine(StartFadeINWebtoon());

    }

    public void Log()
    {
        Debug.Log("Click");
    }

    IEnumerator StartFadeIN()
    {
        imageObj.SetActive(true);
        isStart = true;
        float fadeCount = 0;
        while( fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        SceneManager.LoadScene("Start");
    }

    IEnumerator StartFadeINWebtoon()
    {
        imageObj.SetActive(true);
        isStart = true;
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        SceneManager.LoadScene("WebtoonSence 1");
    }

    IEnumerator StartFadeOUT()
    {
        float fadeCount = 1.1f;
        while (fadeCount > 0)
        {
            fadeCount -= 0.05f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        imageObj.SetActive(false);
    }


}
