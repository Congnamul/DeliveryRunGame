using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomLevel : MonoBehaviour
{
    public Image im;
    
    public GameObject imO;
    int level;

    public Image LevelMM;
    public Sprite[] ImageLevel = new Sprite[5];


    // Start is called before the first frame update
    void Start()
    {
        level = Random.Range(0, 5);
        LevelMM.sprite = ImageLevel[level];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GoLevel()
    {
        imO.SetActive(true);
        StartCoroutine(StartFadeIN());
        ReadyScripts.Instance.NowDanGye = level;
    }

    IEnumerator StartFadeIN()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.01f);
            im.color = new Color(0, 0, 0, fadeCount);
        }

        SceneManager.LoadScene("OnGame");
    }



}
