using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMcheck : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        bool check = ButtonManager.check;
        if (check) { audioSource.mute = false; } else { audioSource.mute=true; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BGMmute()
    {
        audioSource.mute = true;
    } 
}
