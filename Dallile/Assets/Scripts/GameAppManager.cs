using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhoneManager : MonoBehaviour
{
    public static int StartingRandomRange;

    // Update is called once per frame
    void Update()
    {

    }

    void RRR()
    {
        if(StartingRandomRange == 1)
        {
            int Ran = Random.Range(0, 5);

        }
    }




}
