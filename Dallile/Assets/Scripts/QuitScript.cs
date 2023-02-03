using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour
{
    public GameObject Esc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Esc.SetActive(true);
        }
    }

    public void GameQuit()
    {
        GameObject.Find("GameScript").GetComponent<DataManager>().JsonSave();
        Application.Quit();
    }
    public void cancel()
    {
        Esc.SetActive(false);
    }

}
