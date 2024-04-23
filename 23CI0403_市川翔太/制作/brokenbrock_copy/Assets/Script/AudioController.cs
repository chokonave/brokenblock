using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    public AudioClip soundEffect, clearsoundEffect, gameoversoundEffect, loselifesoundEffect, oneupSoundEffect;

    public AudioClip statesoundEffect;

    private AudioSource generalAudioSource; // 効果音用のAudioSource
    private AudioSource stateAudioSource;   // 開始用のAudioSource

    private void Awake()
    {

        stateAudioSource = gameObject.AddComponent<AudioSource>();
        generalAudioSource = gameObject.AddComponent<AudioSource>();
    }
    void Start()
    {
        
        
    }

    void Update()
    {
        // 何か特別な処理が必要ならここに追加
    }

    public void State()
    {
        
        PlaySound(stateAudioSource, statesoundEffect);
    }

    public void Effect()
    {
        PlaySound(generalAudioSource, soundEffect);
    }

    public void ClearSound()
    {
        PlaySound(generalAudioSource, clearsoundEffect);
    }

    public void LostLife()
    {
        PlaySound(generalAudioSource, loselifesoundEffect);
    }

    public void GameOver()
    {
        PlaySound(generalAudioSource, gameoversoundEffect);
    }

    public void Zanki()
    {
        PlaySound(generalAudioSource, oneupSoundEffect);
    }

    private void PlaySound(AudioSource audioSource, AudioClip clip)
    {
        
        audioSource.clip = clip;
        audioSource.Play();
    }
}