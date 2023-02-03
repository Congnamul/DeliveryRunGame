using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public int cnt;
    AudioSource audioSource;
    public AudioClip ClickSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            audioSource.clip = ClickSound;
            audioSource.Play();
        }
    }

    void PlaySound(string action)
    {
        switch (action)
        {

        }
    }





}
