using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    public int isBack = 0;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) && isBack == 0)
        {
            audioSource.Pause();
        }
        else if (Input.GetKeyUp(KeyCode.F1) && isBack == 0)
        {
            isBack = 1;
        }
        else if(Input.GetKeyDown(KeyCode.F1) && isBack == 1)
        {
            audioSource.UnPause();
        }
        else if (Input.GetKeyUp(KeyCode.F1) && isBack == 1)
        {
            isBack = 0;
        }
    }
}
