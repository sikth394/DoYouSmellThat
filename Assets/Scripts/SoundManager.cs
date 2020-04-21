using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] Farts;
    public AudioSource[] Girl;
    float startTime = 0f;
    float holdTime = 2.7f;
    int indexF;
    int indexG;
    bool isPlaying;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("girlTalk", 6.0f, 12.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            startTime = Time.time;
            foreach (AudioSource fart in Farts)
            {
                if (fart.isPlaying)
                {
                    isPlaying = true;
                    break;
                }
                else
                {
                    isPlaying = false;
                }
            }
        }
        if (((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow))) && !isPlaying)
        {
            
            if (startTime + holdTime <= Time.time)
            {
                isPlaying = true;
                indexF = UnityEngine.Random.Range(0, Farts.Length);
                Farts[indexF].Play();
            }
        }
        
    }

    public void girlTalk()
    {
        indexG = UnityEngine.Random.Range(0, Girl.Length);
        Girl[indexG].Play();
    }

    
}
