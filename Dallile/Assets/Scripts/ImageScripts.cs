using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageScripts : MonoBehaviour
{
    public Image WebtoonImage;
    public Sprite[] Webtoon = new Sprite[12];
    int count;
    public int cnt;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cnt == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                WebtoonImage.sprite = Webtoon[count];
                count += 1;
            }
            if (count >= 12)
            {
                SceneManager.LoadScene("Start");
            }
        }

        if( cnt == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                WebtoonImage.sprite = Webtoon[count];
                count += 1;
            }
            if (count >= 5)
            {
                SceneManager.LoadScene("Ready");
            }
        }

        if (cnt == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                WebtoonImage.sprite = Webtoon[count];
                count += 1;
            }
            if (count >= 5)
            {
                SceneManager.LoadScene("Ready");
            }
        }




    }
}
