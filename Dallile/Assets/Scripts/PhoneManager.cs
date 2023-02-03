using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAppManager : MonoBehaviour
{

    Collider col;

    private UnityEngine.EventSystems.EventSystem _eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        _eventSystem = GameObject.Find("StartButton").GetComponent<UnityEngine.EventSystems.EventSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        if (_eventSystem.IsPointerOverGameObject())
        {
            Debug.Log("¶Ñµû¶ó¶Ñµû");
            return;
        }
    }


}
